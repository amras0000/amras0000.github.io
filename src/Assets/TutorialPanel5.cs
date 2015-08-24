using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialPanel5 : MonoBehaviour
{

	List<KeyCode> availableTargets;
	public CitizenSpawner spawner;
	public GameObject Panel6;

	void Start ()
	{
		availableTargets = new List<KeyCode> ();
	}

	void Update ()
	{
		availableTargets.Clear ();
		foreach (GameObject citizen in spawner.citizens) {
			StrollAcrossPalace c = citizen.GetComponent<StrollAcrossPalace> ();
			availableTargets.Add ((KeyCode)System.Enum.Parse (typeof(KeyCode), c.initial.ToString ()));
		}
		foreach (KeyCode k in availableTargets) {
			if (Input.GetKeyDown (k)) {
				Panel6.SetActive (true);
				gameObject.SetActive (false);
				gameObject.GetComponent<TutorialPanel5> ().enabled = false;
			}
		}

	}
}