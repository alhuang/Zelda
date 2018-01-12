using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

	public GameObject link;
	public GameObject camera;
	public float panTime = 10f;

	private static float CAMERA_LR_MOVE = 16f;
	private static float CAMERA_UD_MOVE = 11f;
	private static float LINK_LR_MOVE = 3f;
	private static float LINK_UD_MOVE = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		ArrowKeyMovement arrowKey = other.GetComponent<ArrowKeyMovement> ();
		if (arrowKey != null) { //link, not monster
			StartCoroutine(moveLinkAndCamera(arrowKey));
		}
	}

	IEnumerator moveLinkAndCamera(ArrowKeyMovement arrowKey) {
		string direction = arrowKey.GetDirection();

		float cameraLRAmount = CAMERA_LR_MOVE;
		float cameraUDAmount = CAMERA_UD_MOVE;
		float linkLRAmount = LINK_LR_MOVE;
		float linkUDAmount = LINK_UD_MOVE;

		//get correct movement amount
		if (direction == "South") {
			cameraLRAmount = 0f;
			cameraUDAmount *= -1f;

			linkLRAmount = 0f;
			linkUDAmount *= -1;
		} else if (direction == "North") {
			cameraLRAmount = 0f;

			linkLRAmount = 0f;
		} else if (direction == "West") {
			cameraLRAmount *= -1f;
			cameraUDAmount = 0f;

			linkLRAmount *= -1f;
			linkUDAmount = 0f;
		} else {
			cameraUDAmount = 0f;

			linkUDAmount = 0f;
		}

		Vector3 linkNewPosition = new Vector3 (
			link.transform.position.x + linkLRAmount,
			link.transform.position.y + linkUDAmount,
			link.transform.position.z);

		link.transform.position = linkNewPosition;
		SpriteRenderer linkSR = link.GetComponent<SpriteRenderer> ();
		linkSR.enabled = false;
		arrowKey.SetCanMove (false);

		cameraLRAmount /= panTime;
		cameraUDAmount /= panTime;
		for (int i = 0; i < panTime; i++) {
			camera.transform.position = new Vector3 (
				camera.transform.position.x + cameraLRAmount,
				camera.transform.position.y + cameraUDAmount,
				camera.transform.position.z);
			yield return new WaitForSeconds (1 / panTime);
		}

		linkSR.enabled = true;
		arrowKey.SetCanMove (true);
	}
}
