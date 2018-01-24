using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoors : MonoBehaviour {
	public Sprite newSprite;
	public GameObject door;
	public AudioClip doorOpenSound;

	private Sprite oldSprite;

	void Start() {
		oldSprite = door.GetComponent<SpriteRenderer> ().sprite;
	}

	void Update() {
		Health[] ts = GetComponentsInChildren<Health>();
		if (ts.Length == 0)
		{
			door.GetComponent<BoxCollider> ().center = new Vector3(0, .25f, 0);
			door.GetComponent<BoxCollider> ().size = new Vector3(1, .5f, 1);
			door.GetComponent<SpriteRenderer> ().sprite = oldSprite;
			AudioSource.PlayClipAtPoint(doorOpenSound, Camera.main.transform.position);

			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			Debug.Log ("do stuff");
			other.transform.position += new Vector3 (-1f, 0, 0);
			door.GetComponent<SpriteRenderer> ().sprite = newSprite;
			door.GetComponent<BoxCollider> ().center = Vector3.zero;
			door.GetComponent<BoxCollider> ().size = new Vector3(1, 1, 1);
		}

	}
}
