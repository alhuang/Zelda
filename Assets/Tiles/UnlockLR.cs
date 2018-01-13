using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLR : MonoBehaviour {
	public GameObject door;

	public Sprite sprite;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			Inventory linkventory = other.GetComponent<Inventory> ();
			if (linkventory.GetKeys () < 1) {
				return;
			}

			//use a key, change the tiles of the door, delete self
			linkventory.RemoveKey();

			door.GetComponent<SpriteRenderer> ().sprite = sprite;
			door.GetComponent<BoxCollider> ().enabled = false;

			Destroy (gameObject);

		}
	}
}
