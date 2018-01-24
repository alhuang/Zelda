using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableTile : MonoBehaviour {
	public Vector3 directionToPush;
	public float pushAmount = 1f;
	public GameObject unlockDoor;
	public Sprite newSprite;

	private Vector3 startingLocation;

	// Use this for initialization
	void Start () {
		startingLocation = transform.position;
	}
		
	void OnTriggerStay (Collider other) {
		if (other.tag == "Link") {
			//if pushed one block, then remove collider
			//and unlock door
			if (Mathf.Abs (transform.position.x - startingLocation.x) > 1f ||
			    Mathf.Abs (transform.position.y - startingLocation.y) > 1f) {

				if (unlockDoor != null) {
					unlockDoor.GetComponent<SpriteRenderer> ().sprite = newSprite;
					unlockDoor.GetComponent<BoxCollider> ().enabled = false;
				}
			} else { //push block
				this.transform.position += directionToPush * pushAmount;
			}
		}
	}
}
