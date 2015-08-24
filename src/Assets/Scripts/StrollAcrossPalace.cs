using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StrollAcrossPalace : MonoBehaviour
{

	public float rebelUnrest, innocentUnrest, innocentMoralty;
	public UnrestController unrestController;
	public MoralityCompass compass;
	
	public CitizenSpawner spawner;
	KeyCode target;

	//values to randomize
	bool travellingLeft;
	float speed;
	public char initial;
	public Color color;
	Sprite head;

	public Color[] colors;
	public int[] colorWeights;

	public Sprite[] heads;

	static char[] alphabet = new char[26] {
		'A',
		'B',
		'C',
		'D',
		'E',
		'F',
		'G',
		'H',
		'I',
		'J',
		'K',
		'L',
		'M',
		'N',
		'O',
		'P',
		'Q',
		'R',
		'S',
		'T',
		'U',
		'V',
		'W',
		'X',
		'Y',
		'Z'
	};

	//boundaries
	public float leftEdge, rightEdge, bottomEdge, topEdge;
	public float minSpeed, maxSpeed;

	public Camera streetCam;
	public CameraControl cameraControl;
	public UnityEngine.UI.InputField inputField;

	void Start ()
	{
		spawner = GameObject.FindGameObjectWithTag ("Street").GetComponent<CitizenSpawner> ();
		streetCam = GameObject.FindGameObjectWithTag ("Street Cam").GetComponent<Camera> ();
		cameraControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CameraControl> ();
		unrestController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<UnrestController> ();
		inputField = GameObject.FindGameObjectWithTag ("Input Field").GetComponent<UnityEngine.UI.InputField> ();
		compass = GameObject.FindGameObjectWithTag ("Compass").GetComponent<MoralityCompass> ();

		//randomize direction of travel
		travellingLeft = (Random.Range (0, 2) == 1);

		//move to appropriate side and rotation
		float xPos = 0; //failsafe
		if (travellingLeft) {
			transform.Rotate (new Vector3 (0, 180, 0));
			GameObject _name = transform.FindChild ("Name").gameObject;
			_name.transform.position += new Vector3 (-.4f, 0, -.5f);
			_name.transform.Rotate (new Vector3 (0, 180, 0));
			xPos = rightEdge;
		} else {
			xPos = leftEdge;
		}

		//randomize vertical position
		float yPos = Random.Range (bottomEdge, topEdge);

		transform.localPosition = new Vector3 (xPos, yPos, 0);

		//randomize other variables
		speed = Random.Range (minSpeed, maxSpeed);
		head = heads [Random.Range (0, heads.Count ())];
		transform.FindChild ("Head").GetComponent<SpriteRenderer> ().sprite = head;


		//color
		colorWeights [0] *= unrestController.anarchy + 1;

		int colorChoice = Random.Range (0, colorWeights.Sum ());
		int runningSum = 0;
		for (int i = 0; i < colorWeights.Count(); i++) {
			runningSum += colorWeights [i];
			if (colorChoice < runningSum) {
				color = colors [i];
				break;
			}
		}
		GetComponent<SpriteRenderer> ().color = color;
		
		//make sure not to duplicate letters from other citizens
		List<char> availableLetters = alphabet.ToList ();
		foreach (GameObject citizen in spawner.citizens) {
			if (citizen != null) {
				char n = citizen.GetComponent<StrollAcrossPalace> ().initial;
				if (availableLetters.Contains (n)) {
					availableLetters.Remove (n);
				}
			}
		}
		initial = availableLetters [Random.Range (0, availableLetters.Count)];
		GetComponentInChildren<TextMesh> ().text = initial.ToString ();
		target = (KeyCode)System.Enum.Parse (typeof(KeyCode), initial.ToString ());

	}
	
	void Update ()
	{
		//move in the proper direction
		if (travellingLeft)
			transform.localPosition -= new Vector3 (speed * Time.deltaTime, 0, 0);
		else
			transform.localPosition += new Vector3 (speed * Time.deltaTime, 0, 0);		

		//we've gone as far as we can
		if (transform.localPosition.x > rightEdge || transform.localPosition.x < leftEdge) {
			if (color == colors [0]) { //we let a rebel through
				unrestController.IncreaseUnrest (rebelUnrest);
				cameraControl.warning (streetCam);
			}

			Destroy (gameObject);
		}

		//we got shot on the way
		if (Input.GetKeyDown (target) && !inputField.enabled) {
			//die
			if (color != colors [0]) {
				unrestController.IncreaseUnrest (innocentUnrest);
				compass.ChangeMorality (-innocentMoralty);
				cameraControl.warning (streetCam);

			}

			spawner.gameObject.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject);
		}
	}

}
