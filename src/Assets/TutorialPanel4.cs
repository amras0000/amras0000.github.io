using UnityEngine;
using System.Collections;

public class TutorialPanel4 : MonoBehaviour
{

	
	public GameObject Panel5;
	public CitizenSpawner spawner;
	KeyCode rebel_name;
	
	void Update ()
	{
		foreach (GameObject citizen in spawner.citizens) {
			StrollAcrossPalace c = citizen.GetComponent<StrollAcrossPalace> ();
			if (c.color == c.colors [0]) {
				rebel_name = (KeyCode)System.Enum.Parse (typeof(KeyCode), c.initial.ToString ());
			}
		}
		if (Input.GetKeyDown (rebel_name)) {
			Panel5.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
