using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableTile : MonoBehaviour {
	public Vector3 directionToPush;
	public float pushAmount = .05f;
	public GameObject unlockDoor;
	public Sprite newSprite;

	private Vector3 finalLocation;
	private BoxCollider triggerBox;

	// Use this for initialization
	void Start () {
		finalLocation = transform.position + directionToPush;

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
			if (Mathf.Abs (transform.position.x - finalLocation.x) < pushAmount &&
				Mathf.Abs (transform.position.y - finalLocation.y) < pushAmount) {
				triggerBox.enabled = false;

				unlockDoor.GetComponent<SpriteRenderer> ().sprite = newSprite;
				unlockDoor.GetComponent<BoxCollider> ().enabled = false;
			}
		}
	}
}
