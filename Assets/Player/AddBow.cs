using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBow : MonoBehaviour {
	public AudioClip BoomSound;


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			other.GetComponent<Attack> ().hasBow = true;
			AudioSource.PlayClipAtPoint(BoomSound, Camera.main.transform.position);
			Destroy (gameObject);
		}
	}
}
