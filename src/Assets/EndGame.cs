using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{
	bool gameOver;
	public GameObject[] ObjectsToHide;
	public Camera endCam;

	void Start ()
	{
	
	}
	
	public void endGame (GameObject endSlate)
	{
		foreach (GameObject o in ObjectsToHide) {
			o.SetActive (false);
		}
		endCam.gameObject.SetActive (true);
		endCam.enabled = true;
		endSlate.SetActive (true);
		gameOver = true;
	}

	void Update ()
	{
		if (gameOver && Input.GetButtonDown ("Reset")) {
			Application.LoadLevel (1);
		}
	}
}
