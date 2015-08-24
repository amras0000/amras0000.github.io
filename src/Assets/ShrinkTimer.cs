using UnityEngine;
using System.Collections;

public class ShrinkTimer : MonoBehaviour
{
	Vector3 maxSize;
	public CheckHeadlines headline;

	public void Start ()
	{
		maxSize = transform.localScale;
		StartCoroutine (resetSize ());
	}

	public void Update ()
	{
		transform.localScale -= new Vector3 (0,
		                                    (maxSize.y / headline.printDelay) * Time.deltaTime,
		                                     0);
	}

	IEnumerator resetSize ()
	{
		while (true) {
			yield return new WaitForSeconds (headline.printDelay);
			transform.localScale = maxSize;
		}
	}
}
