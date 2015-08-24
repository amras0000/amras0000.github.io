using UnityEngine;
using System.Collections;

public class TutorialPanel6 : MonoBehaviour
{

	public GameObject Panel7;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Panel7.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
