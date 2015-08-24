using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class prisonerSpawn : MonoBehaviour
{
	
	public GameObject prisoner;
	public List<GameObject> prisoners;
	public float minDelay, maxDelay;
	public float leftEdge, rightEdge;
	public UnrestController unrestcontroller;
	
	void Start ()
	{
		prisoners = new List<GameObject> ();
		StartCoroutine (spawn ());
	}
	
	IEnumerator spawn ()
	{
		GameObject clone;
		while (true) {
			clone = Instantiate (prisoner);
			clone.transform.SetParent (transform);
			clone.transform.localPosition = new Vector3 (
				Random.Range (leftEdge, rightEdge),
				-6, 0);
			prisoners.Add (clone);
			yield return new WaitForSeconds (Random.Range (
				minDelay / (unrestcontroller.anarchy + 1),
				maxDelay / (unrestcontroller.anarchy + 1)));
		}
	}
	
	void Update ()
	{
		foreach (GameObject c in prisoners) {
			if (c == null) {
				prisoners.Remove (c);
			}
		}
	}
}
