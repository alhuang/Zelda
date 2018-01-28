using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableTile : MonoBehaviour {
	public GameObject unlockDoor;
	public Sprite newSprite;
	public bool pushed = false;
	//public string moveDirection = "";
		
	void OnTriggerStay (Collider other) {
		if (other.tag == "Link") {
			//if pushed one block, then remove collider
			//and unlock door
			if (pushed) {


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

				StartCoroutine (pushDoor (directionToPush));

			}
		}
	}

	IEnumerator pushDoor(Vector3 direction) {
		pushed = true;

		for (int i = 0; i < 20; ++i) {
			transform.position += direction / 20f;
			yield return null;
		}

		if (unlockDoor != null) {
			unlockDoor.GetComponent<SpriteRenderer> ().sprite = newSprite;
			unlockDoor.GetComponent<BoxCollider> ().enabled = false;
		}
	}
}
