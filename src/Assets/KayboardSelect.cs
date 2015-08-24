using UnityEngine;
using System.Collections;

public class KayboardSelect : MonoBehaviour
{
	
	UnityEngine.UI.InputField inpu;
	public UnityEngine.UI.Text headline;
	public CameraControl cameraControl;
	public Camera newsCam;
	
	void Start ()
	{
		inpu = GetComponent<UnityEngine.UI.InputField> ();
		inpu.enabled = false;
	}
	void Update ()
	{
		if (Input.GetButtonDown ("Edit Headlines")) {
			if (!inpu.enabled) {
				Debug.Log ("input inactive");
				inpu.text = "";
				headline.text = "No Headline";
				inpu.enabled = true;
				Debug.Log ("activating input field");
				inpu.ActivateInputField ();
				cameraControl.highlight (newsCam, true);
			} else {
				inpu.enabled = false;
				cameraControl.highlight (newsCam, false);
			}
		}
	}

	public void disableField ()
	{
		inpu.enabled = false;
		cameraControl.highlight (newsCam, false);

	}
}