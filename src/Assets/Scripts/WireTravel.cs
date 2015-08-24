using UnityEngine;
using System.Collections;

public class WireTravel : MonoBehaviour
{

	public float speed;
	public float maxDistanceL, maxDistanceR;
	bool travellingLeft = true;

	void Start ()
	{
		//start travelling to the right
		resetLeft ();
	}
	
	void Update ()
	{
		//move in the proper direction
		if (travellingLeft)
			transform.localPosition -= new Vector3 (speed * Time.deltaTime, 0, 0);
		else
			transform.localPosition += new Vector3 (speed * Time.deltaTime, 0, 0);

		//bounce if we've hit a boundary
		if (transform.localPosition.x < maxDistanceL) {
			resetLeft ();
		} else if (transform.localPosition.x > maxDistanceR) {
			resetRight ();
		}
	}

	//reset the position to the left edge and start travelling right
	void resetLeft ()
	{
		transform.localPosition = new Vector3 (maxDistanceL, transform.localPosition.y, transform.localPosition.z);
		travellingLeft = false;
	}

	//opposite of resetLeft
	void resetRight ()
	{
		transform.localPosition = new Vector3 (maxDistanceR, transform.localPosition.y, transform.localPosition.z);
		travellingLeft = true;
	}
}
