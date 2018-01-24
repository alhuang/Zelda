using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoomerang : MonoBehaviour {
	public AudioClip BoomSound;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			other.GetComponent<Attack> ().hasBoomerang = true;
			AudioSource.PlayClipAtPoint(BoomSound, Camera.main.transform.position);
			Destroy (gameObject);
		}
	}
}
