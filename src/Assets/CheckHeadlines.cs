using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class CheckHeadlines : MonoBehaviour
{

	Text headline;
	public InputField input;

	public float printDelay;
	public string[] benignHeadlines;
	public string[] slanderousHeadlines;
	string[] headlines;

	public UnrestController unrestController;
	public CameraControl cameraController;
	public Camera newsCam;
	public float unrestValue;

	void Start ()
	{
		headline = GetComponent <Text> ();

		//merge the two headline lists
		headlines = new string[benignHeadlines.Length + slanderousHeadlines.Length];
		System.Array.Copy (benignHeadlines, headlines, benignHeadlines.Length);
		System.Array.Copy (slanderousHeadlines, 0, headlines, benignHeadlines.Length, slanderousHeadlines.Length);

		StartCoroutine (NewHeadline (printDelay));
	}

	IEnumerator NewHeadline (float delay)
	{
		while (true) {
			input.GetComponent<KayboardSelect> ().disableField ();
			input.text = headlines [Random.Range (0, headlines.Length)];

			//reset the input
			yield return new WaitForSeconds (delay);
			//check if a slanderous headline got through
			if (slanderousHeadlines.Contains (headline.text)) {
				//increase unrest for the headline
				unrestController.IncreaseUnrest (unrestValue);
				cameraController.warning (newsCam);
			}
		}
	}
}
