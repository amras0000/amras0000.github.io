using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

	static Rect notARect;
	
	public Rect[] screenPositions; //where can we place the cameras?
	public GameObject[] warnings; //screen flashes
	public GameObject[] highlights; //for news
	public Camera newspaperCam, streetCam, wireCam, prisonCam, policyCam;
	Camera[] cameras;


	Vector3 mousePos;

	void Start ()
	{
		cameras = new Camera[] {newspaperCam, streetCam, wireCam, prisonCam};
		notARect = new Rect ();
	}
	
	void Update ()
	{


		//check for camera control buttons
		if (Input.GetButtonDown ("Newspaper")) {
			switchCameraPosition (newspaperCam);
		} else if (Input.GetButtonDown ("Wiretap")) {
			switchCameraPosition (wireCam);
		} else if (Input.GetButtonDown ("Prison")) {
			switchCameraPosition (prisonCam);
		} else if (Input.GetButtonDown ("Street")) {
			switchCameraPosition (streetCam);
		}
	}

	void switchCameraPosition (Camera cam)
	{
		//store the old camera position
		Rect oldPos = cam.rect;
		//determine where to place camera
		Rect newPos = activeZone ();
		
		//make sure camera is enabled
		if (!cam.enabled) {
			cam.enabled = true;
		}
		//disable the camera if player clicked on it
		else if (newPos == cam.rect && cam.enabled) {
			cam.enabled = false;
		}
		//make sure the activeZone is a valid rect and put the camera in its new home, swapping out anything already there
		if (newPos != notARect) {
			foreach (Camera c in cameras) { //check all cameras
				if (c.rect == newPos) {	//we found a camera at the destination
					if (newPos != oldPos) {
						c.rect = oldPos;//replace it with the other camera
						break;
					} else if (c != cam) {//we had overlapping cameras?
						c.enabled = false;
					}
				}
			}
			cam.rect = newPos;
		}
	}

	public Rect activeZone ()
	{
		//determine which zone of the screen the mouse is over
		Vector3 mousePos = Input.mousePosition;
		foreach (Rect pos in screenPositions) {
			if (adjusted (pos).Contains (mousePos)) {
				return pos;
			}
		}
		return notARect;
	}

	//accounts for screen resolution
	Rect adjusted (Rect r)
	{
		return new Rect (r.x * Screen.width,
		                 r.y * Screen.height,
		                 r.width * Screen.width,
		                 r.height * Screen.height);
	}

	public void warning (Camera cam)
	{
		Debug.Log ("warning called");
		for (int i = 0; i < screenPositions.Length; i++) {
			if (cam.rect == screenPositions [i]) {
				//flash
				StartCoroutine (flash (warnings [i]));

			}
		}
	}
	IEnumerator flash (GameObject w)
	{
		Debug.Log ("flash called");
		w.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		w.SetActive (false);
	}

	public void highlight (Camera cam, bool enabled)
	{
		for (int i = 0; i < screenPositions.Length; i++) {
			if (cam.rect == screenPositions [i]) {
				highlights [i].SetActive (enabled);
			}
		}
	}
}
