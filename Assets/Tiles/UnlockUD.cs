using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockUD : MonoBehaviour {
	public GameObject LeftDoor;
	public GameObject RightDoor;

	public Sprite LDSprite;
	public Sprite RDSprite;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			Inventory linkventory = other.GetComponent<Inventory> ();
			if (linkventory.GetKeys () < 1) {
				return;
			}

			//use a key, change the tiles of the door, delete self
			linkventory.RemoveKey();

			LeftDoor.GetComponent<SpriteRenderer> ().sprite = LDSprite;
			RightDoor.GetComponent<SpriteRenderer> ().sprite = RDSprite;
			LeftDoor.GetComponent<BoxCollider> ().enabled = false;
			RightDoor.GetComponent<BoxCollider> ().enabled = false;

			Destroy (gameObject);

		}
	}
}
