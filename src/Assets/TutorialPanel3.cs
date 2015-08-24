using UnityEngine;
using System.Collections;

public class TutorialPanel3 : MonoBehaviour
{

	
	public GameObject Panel4;

	void Update ()
	{
		if (Input.GetButtonDown ("Street")) {
			Panel4.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
