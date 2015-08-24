using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnarchyStars : MonoBehaviour
{
	int starCount;
	List<GameObject> starList;
	public GameObject star;
	public Vector3 starHeight;
	public float starWidth;

	void Start ()
	{
		starList = new List<GameObject> ();
	}

	public void addStar ()
	{
		Debug.Log ("Adding Star");
		starCount += 1;
		GameObject newStar = Instantiate (star);
		newStar.transform.SetParent (transform);
		newStar.transform.localPosition = starHeight;
		starList.Add (newStar);
		balanceStars ();
	}
	public void removeStar ()
	{
		starCount -= 1;
		Destroy (starList [0]);
		starList.RemoveAt (0);
	}

	void balanceStars ()
	{
		for (int i = 0; i < starList.Count; i++) {
			Vector3 pos = starList [i].transform.localPosition;
			pos.x = (starWidth * ((i + 1f) / (starCount + 1f))) - starWidth / 2f;
			starList [i].transform.localPosition = pos;
		}
	}
}
