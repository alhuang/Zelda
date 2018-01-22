using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBow : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			other.GetComponent<Attack> ().hasBow = true;
			Destroy (gameObject);
		}
	}
}
