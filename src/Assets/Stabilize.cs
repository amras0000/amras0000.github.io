using UnityEngine;
using System.Collections;

public class Stabilize : MonoBehaviour
{

	Quaternion initialRot;

	void Start ()
	{
		initialRot = transform.rotation;
	}
	void FixedUpdate ()
	{
		transform.rotation = initialRot;
	}
}
