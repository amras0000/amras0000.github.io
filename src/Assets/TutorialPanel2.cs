using UnityEngine;
using System.Collections;

public class TutorialPanel2 : MonoBehaviour
{
	public GameObject tutorialGroup;
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			tutorialGroup.SetActive (false);
		}
	}
}