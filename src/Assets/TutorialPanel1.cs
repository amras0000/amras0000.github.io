using UnityEngine;
using System.Collections;

public class TutorialPanel1 : MonoBehaviour
{

	public GameObject Panel2;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Panel2.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
