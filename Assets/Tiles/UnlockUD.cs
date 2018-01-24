using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockUD : MonoBehaviour {
	public GameObject LeftDoor;
	public GameObject RightDoor;
	public AudioClip doorOpen;

	public Sprite LDSprite;
	public Sprite RDSprite;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			if (other.GetComponent<ArrowKeyMovement> ().GetDirection () != "North") {
				return;
			}
			Inventory linkventory = other.GetComponent<Inventory> ();
			if (linkventory.GetKeys () < 1) {
				return;
			}

			AudioSource.PlayClipAtPoint(doorOpen, Camera.main.transform.position);
			//use a key, change the tiles of the door, delete self
			linkventory.RemoveKey();

			LeftDoor.GetComponent<SpriteRenderer> ().sprite = LDSprite;
			RightDoor.GetComponent<SpriteRenderer> ().sprite = RDSprite;
			LeftDoor.GetComponent<BoxCollider> ().center = new Vector3(-.25f, 0, 0);
			LeftDoor.GetComponent<BoxCollider> ().size = new Vector3(.5f, 0, 0);
			RightDoor.GetComponent<BoxCollider> ().center = new Vector3(.25f, 0, 0);
			RightDoor.GetComponent<BoxCollider> ().size = new Vector3(.5f, 0, 0);

			Destroy (gameObject);

		}
	}
}
