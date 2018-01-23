using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableTile : MonoBehaviour {
	public Vector3 directionToPush;
	public float pushAmount = 1f;
	public GameObject unlockDoor;
	public Sprite newSprite;

	private Vector3 startingLocation;
	private BoxCollider triggerBox;

	// Use this for initialization
	void Start () {
		startingLocation = transform.position;

		BoxCollider[] boxes = GetComponents<BoxCollider> ();
		foreach(BoxCollider box in boxes) {
			if (box.isTrigger) {
				triggerBox = box;
			}
		}
	}
		
	void OnTriggerStay (Collider other) {
		if (other.tag == "Link") {
			this.transform.position += directionToPush * pushAmount;

			//if pushed one block, then remove collider
			//and unlock door
			if (Mathf.Abs (transform.position.x - startingLocation.x) > 1f ||
				Mathf.Abs (transform.position.y - startingLocation.y) > 1f) {
				triggerBox.enabled = false;

				if (unlockDoor != null) {
					unlockDoor.GetComponent<SpriteRenderer> ().sprite = newSprite;
					unlockDoor.GetComponent<BoxCollider> ().enabled = false;
				}
			}
		}
	}
}
