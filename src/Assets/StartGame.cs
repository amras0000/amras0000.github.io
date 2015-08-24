using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{

	public bool antiSeizureMode;

	public void OnMouseDown ()
	{
		if (antiSeizureMode) {
			Application.LoadLevel (2);
		} else {
			Application.LoadLevel (1);
		}
	}

	public void setAntiSeizureMode ()
	{
		antiSeizureMode = true;
	}
}
