using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour {
	public GameObject WinGameUI;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			WinGameUI.SetActive(true);
		}
	}
}
