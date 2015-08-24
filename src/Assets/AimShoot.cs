using UnityEngine;
using System.Collections;

public class AimShoot : MonoBehaviour
{

	public Vector3 guard;
	public float maxXOfAim, minAim, maxAim;
	LineRenderer lineRenderer;
	public Camera prisonCam;
	Vector3 endpoint;
	public AudioSource shot;

	public void Start ()
	{
		shot = GetComponent<AudioSource> ();

		//convert everything from local to global coords
		guard += transform.position;
		maxXOfAim += transform.position.x;
		maxAim += transform.position.y;
		minAim += transform.position.y;

		//init lineRender
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetVertexCount (2);
		lineRenderer.SetPosition (0, guard);
	}

	public void Update ()
	{
		if (prisonCam.enabled) {
			Vector3 mousePos = Input.mousePosition;
			mousePos = prisonCam.ScreenToWorldPoint (mousePos);
			mousePos.z = 0;
			endpoint = new Vector3 ();
			endpoint.x = maxXOfAim;
			endpoint.y = guard.y + (((maxXOfAim - guard.x) / (guard.x - mousePos.x)) *
				(guard.y - mousePos.y));
			endpoint.y = Mathf.Clamp (endpoint.y, minAim, maxAim);
			endpoint.z = guard.z;
			lineRenderer.SetPosition (1, endpoint);
		}

		if (Input.GetMouseButtonDown (0) && prisonCam.enabled) {
			shot.Play ();
			Debug.Log ("called fire");
			RaycastHit2D hit = Physics2D.Raycast (guard, endpoint - guard);
			if (hit.collider != null) {
				Debug.Log ("we found a target");
				GameObject target = hit.collider.gameObject;
				if (target.CompareTag ("prisoner")) {
					Destroy (target);
				}
			}
		}


	}

}