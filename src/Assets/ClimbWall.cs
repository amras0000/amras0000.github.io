using UnityEngine;
using System.Collections;

public class ClimbWall : MonoBehaviour
{

	public float speed;
	public float wallHeight, wallWidth, minHeight;
	Vector3 initialPos;

	public UnrestController unrestController;
	public CameraControl cameraControl;
	public Camera prisonCam;
	public float escapePenalty;

	void Start ()
	{
		cameraControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<CameraControl> ();
		unrestController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<UnrestController> ();
		prisonCam = GameObject.FindGameObjectWithTag ("PrisonCam").GetComponent<Camera> ();
		initialPos = transform.position;
	}
	
	void Update ()
	{
		//have we reached the top yet?
		if (transform.position.y - initialPos.y < wallHeight) {
			transform.localPosition += new Vector3 (0, speed * Time.deltaTime, 0);
		}
		//have we moved across the top yet?
		else if (transform.position.x < initialPos.x + wallWidth) {
			transform.localPosition += new Vector3 (speed * Time.deltaTime, 0, 0);
		}
		//yes we have
		else {
			unrestController.IncreaseUnrest (escapePenalty);
			cameraControl.warning (prisonCam);
			Destroy (gameObject);
		}
	}
}
