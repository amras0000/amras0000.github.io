using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnrestMeter : MonoBehaviour, UnrestListener
{


	public void updateUnrest (float unrest)
	{
		transform.localScale = new Vector3 (transform.localScale.x,
		                                   unrest / 50,
		                                   transform.localScale.z);
	}
}
