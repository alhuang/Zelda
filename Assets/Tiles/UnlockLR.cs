using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLR : MonoBehaviour {
	public GameObject door;
	public AudioClip doorOpen;
	public Sprite sprite;

	void OnTriggerStay(Collider other) {
		if (other.tag == "Link") {
			if (other.GetComponent<ArrowKeyMovement> ().GetDirection () == "West" ||
			   other.GetComponent<ArrowKeyMovement> ().GetDirection () == "East") {

				Inventory linkventory = other.GetComponent<Inventory> ();
				if (linkventory.GetKeys () < 1) {
					return;
				}

				AudioSource.PlayClipAtPoint(doorOpen, Camera.main.transform.position);
				//use a key, change the tiles of the door, delete self
				linkventory.RemoveKey ();

				door.GetComponent<SpriteRenderer> ().sprite = sprite;
				door.GetComponent<BoxCollider> ().center = new Vector3 (0, .25f, 0);
				door.GetComponent<BoxCollider> ().center = new Vector3 (0, .5f, 0);

				Destroy (gameObject);
			}
		}
	}
}
