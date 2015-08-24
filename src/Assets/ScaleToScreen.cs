using UnityEngine;
using System.Collections;

public class ScaleToScreen : MonoBehaviour
{

	public Camera mainCam;

	void Update ()
	{
			
		float height = mainCam.orthographicSize * 2.0f;
		float width = height * Screen.width / Screen.height;
		transform.localScale = new Vector3 (width, height, 1f);
	}
}
