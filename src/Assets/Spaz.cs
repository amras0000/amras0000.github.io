using UnityEngine;
using System.Collections;

public class Spaz : MonoBehaviour
{
	public GameObject child;

	public void FixedUpdate ()
	{
		float rot = Random.Range (0, 360);
		transform.Rotate (new Vector3 (0, 0, rot));
		child.transform.Rotate (new Vector3 (0, 0, -rot));
	}

}
