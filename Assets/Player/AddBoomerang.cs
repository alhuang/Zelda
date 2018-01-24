using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoomerang : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			other.GetComponent<Attack> ().hasBoomerang = true;
			Destroy (gameObject);
		}
	}
}
