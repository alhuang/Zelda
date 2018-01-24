using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableTile : MonoBehaviour {
	public float pushAmount = 1f;
	public GameObject unlockDoor;
	public Sprite newSprite;
	//public string moveDirection = "";

	private Vector3 startingLocation;

	// Use this for initialization
	void Start () {
		startingLocation = transform.position;
	}
		
	void OnTriggerStay (Collider other) {
		if (other.tag == "Link") {
			//if pushed one block, then remove collider
			//and unlock door
			if (Mathf.Abs (transform.position.x - startingLocation.x) > .99f ||
			    Mathf.Abs (transform.position.y - startingLocation.y) > .99f) {


			} else { //push block
				Vector3 directionToPush = Vector3.zero;

				string direction = other.GetComponent<ArrowKeyMovement> ().GetDirection ();

				/*if (moveDirection == "") {
					moveDirection = direction;
				} else {
					if (direction != moveDirection) {
						return;
					}
				}*/

				if (direction == "North") {
					directionToPush.y = 1f;
				} else if (direction == "South") {
					directionToPush.y = -1f;
				} else if (direction == "East") {
					directionToPush.x = 1f;
				} else if (direction == "West") {
					directionToPush.x = -1f;
				}

				this.transform.position += directionToPush * pushAmount;

				if (unlockDoor != null) {
					unlockDoor.GetComponent<SpriteRenderer> ().sprite = newSprite;
					unlockDoor.GetComponent<BoxCollider> ().enabled = false;
				}
			}
		}
	}
}
