using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

	public GameObject link;
	public GameObject camera;

	private float cameraLRAmount = 16f;
	private float cameraUDAmount = 11f;
	private float linkLRAmount = 3f;
	private float linkUDAmount = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		ArrowKeyMovement arrowKey = other.GetComponent<ArrowKeyMovement> ();
		if (arrowKey != null) { //link, not monster
			string direction = arrowKey.GetDirection();

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

			link.transform.position = new Vector3 (
				link.transform.position.x + linkLRAmount,
				link.transform.position.y + linkUDAmount,
				link.transform.position.z);

			camera.transform.position = new Vector3 (
				camera.transform.position.x + cameraLRAmount,
				camera.transform.position.y + cameraUDAmount,
				camera.transform.position.z);
		}
	}
}
