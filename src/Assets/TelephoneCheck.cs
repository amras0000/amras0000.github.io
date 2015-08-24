using UnityEngine;
using System.Collections;
using System.Linq;


public class TelephoneCheck : MonoBehaviour
{

	public string[] benignCalls;
	public string[] rebelCalls;
	string[] calls;

	public UnrestController unrestController;
	public MoralityCompass compass;
	public float unrestValue, falsePositiveValue;


	public TextMesh text;
	WireTravel wire;

	public Camera wireCam;
	public CameraControl cameraControl;

	void Start ()
	{
		wire = GetComponent<WireTravel> ();

		for (int i = 0; i<benignCalls.Length; i++) {
			benignCalls [i] = benignCalls [i].Replace ("\\", "\n");
		}
		for (int i = 0; i< rebelCalls.Length; i++) {
			rebelCalls [i] = rebelCalls [i].Replace ("\\", "\n");
		}

		//merge the two call lists
		calls = new string[benignCalls.Length + rebelCalls.Length];
		System.Array.Copy (benignCalls, calls, benignCalls.Length);
		System.Array.Copy (rebelCalls, 0, calls, benignCalls.Length, rebelCalls.Length);
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Tap")) {
			//start an animation
			if (benignCalls.Contains (text.text)) {
				//play another animation
				compass.ChangeMorality (-falsePositiveValue);
				cameraControl.warning (wireCam);
			}
			text.text = "";
		}

		//update text if neccessary
		if (transform.localPosition.x <= wire.maxDistanceL || transform.localPosition.x >= wire.maxDistanceR) {
			if (rebelCalls.Contains (text.text)) {
				unrestController.IncreaseUnrest (unrestValue);
				cameraControl.warning (wireCam);
			}
			text.text = calls [Random.Range (0, calls.Length)];
		}
	}

}
