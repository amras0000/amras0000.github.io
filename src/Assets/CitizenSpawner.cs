using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CitizenSpawner : MonoBehaviour
{

	public GameObject citizen;
	public List<GameObject> citizens;
	public float delay;

	void Start ()
	{
		citizens = new List<GameObject> ();
		StartCoroutine (spawn (delay));
	}
	
	IEnumerator spawn (float delay)
	{
		GameObject clone;
		while (true) {
			clone = Instantiate (citizen);
			clone.transform.SetParent (transform);
			citizens.Add (clone);
			yield return new WaitForSeconds (delay);
		}
	}

	void Update ()
	{
		foreach (GameObject c in citizens) {
			if (c == null) {
				citizens.Remove (c);
			}
		}
	}
}
