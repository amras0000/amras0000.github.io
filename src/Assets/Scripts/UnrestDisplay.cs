using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class UnrestDisplay : MonoBehaviour, UnrestListener
{
	Text textDisplay;

	void Start ()
	{
		textDisplay = gameObject.GetComponent<Text> ();
		textDisplay.text = "testing 1";
	}

	public void updateUnrest (float unrest)
	{
		textDisplay.text = Mathf.FloorToInt (unrest).ToString () + "/100";
	}
}
