using UnityEngine;
using System.Collections;

public class MoralityCompass : MonoBehaviour
{

	public float morality;
	public float recoverRate;
	public EndGame endGame;
	public GameObject goodEnd, badEnd;
	
	public void ChangeMorality (float amount)
	{
		morality += amount;
	}

	void Update ()
	{
		morality += recoverRate * Time.deltaTime;
		transform.GetChild (0).transform.localRotation = Quaternion.Euler (0, 0, -morality * 0.9f + 90);

		if (morality <= -100) {
			endGame.endGame (badEnd);
		}
		if (morality >= 100) {
			endGame.endGame (goodEnd);
		}
	}
}
