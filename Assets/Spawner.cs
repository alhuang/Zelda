using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	private Enemy_Movement[] enemies;
	private float[] speeds;

	void Start() {
		enemies = GetComponentsInChildren<Enemy_Movement> ();
		speeds = new float[2];
		for (int i = 0; i < enemies.Length; i++) {
			speeds [i] = enemies [i].GetMovementSpeed();
			enemies [i].movement_speed = 0f;
		}
	}

	//activate all enemies
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			for (int i = 0; i < enemies.Length; i++) {
				if (enemies [i] != null) {
					enemies [i].movement_speed = speeds [i];
				}
			}
		}
	}

	//activate all enemies
	void OnTriggerExit(Collider other) {
		if (other.tag == "Link") {
			for (int i = 0; i < enemies.Length; i++) {
				if (enemies [i] != null) {
					enemies [i].movement_speed = 0f;
				}
			}
		}
	}

}
