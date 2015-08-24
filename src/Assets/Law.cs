using UnityEngine;
using System.Collections;

public class Law : MonoBehaviour
{
	static int moralityDrop = 34;
	public int law;
	GameObject description;
	public bool used = false;
	MoralityCompass compass;
	UnrestController unrestController;

	public void Start ()
	{
		description = transform.FindChild ("Description").gameObject;
		description.SetActive (false);
		compass = GameObject.FindGameObjectWithTag ("Compass").GetComponent<MoralityCompass> ();
		unrestController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<UnrestController> ();
	}

	public void OnMouseEnter ()
	{
		description.SetActive (true);
	}

	public void OnMouseExit ()
	{
		description.SetActive (false);
	}

	public void OnMouseDown ()
	{
		Debug.Log ("click");
		switch (law) {
		case 0:
			//Death Penalty
			break;
		case 1:
			//Shoot to Kill
			break;
		case 2:
			//Assassination
			break;
		case 3:
			//Wiretapping
			break;
		case 4:
			//Secret Police
			break;
		case 5:
			//Censorship
			break;
		case 6:
			//Mock Trials
			break;
		case 7:
			//Bribes
			if (!used)
				StartCoroutine (decreaseAnarchy ());
			break;
		case 8:
			//Education Reform
			if (!used)
				StartCoroutine (decreaseUnrest ());
			break;
		default:
			break;
		}
		StartCoroutine ("Activate");
		compass.ChangeMorality (-moralityDrop);
	}

	IEnumerator Activate ()
	{
		used = true;
		yield return new WaitForEndOfFrame ();
	}

	IEnumerator decreaseAnarchy ()
	{
		while (true) {
			if (unrestController.anarchy > 0) {
				unrestController.anarchy --;
				unrestController.anarchyStars.removeStar ();
			}
			yield return new WaitForSeconds (120);
		}
	}

	IEnumerator decreaseUnrest ()
	{
		while (true) {
			unrestController.IncreaseUnrest (-(Mathf.Abs ((unrestController.decay * Time.deltaTime) / 2f)));
			yield return new WaitForEndOfFrame ();
		}
	}
}
