using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UnrestController : MonoBehaviour
{

	public float unrest;
	public int anarchy;
	public float decay;
	public MoralityCompass compass;
	public EndGame endGame;
	public GameObject badEnding;

	List<UnrestListener> listeners = new List<UnrestListener> ();
	//things to add to listeners list
	public GameObject unrestDisplay;

	public AnarchyStars anarchyStars;

	void Start ()
	{
		//really hacky but I can't figure out a way to do this in the editor otherwise
		listeners.Add (unrestDisplay.GetComponent<UnrestListener> ());
	}

	void Update ()
	{
		unrest -= decay * (compass.morality / 100f) * Time.deltaTime;

		if (unrest >= 100) {
			anarchy += 1;
			unrest = 0;
			anarchyStars.addStar ();
		}

		if (unrest < 0) {
			unrest = 0;
		}

		if (anarchy >= 3) {
			endGame.endGame (badEnding);
		}

		foreach (UnrestListener listener in listeners) {
			listener.updateUnrest (unrest);
		}

	}

	public void IncreaseUnrest (float increase)
	{
		unrest += increase;
	}
}
