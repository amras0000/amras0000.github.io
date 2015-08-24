using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{

	public InputField input;
	Text text;
	string oldInput;

	void Start ()
	{
		text = GetComponent<Text> ();
	}
	
	void Update ()
	{
		text.text = input.text;
		if (text.text == "") {
			text.text = "No Headline";
		}
	}
}
