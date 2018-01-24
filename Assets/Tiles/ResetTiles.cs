using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTiles : MonoBehaviour {
	public Transform[] pushableTiles;

	private Vector3[] locations;

	// Use this for initialization
	void Start () {
		locations = new Vector3[pushableTiles.Length];
		for (int i = 0; i < pushableTiles.Length; i++) {
			locations[i] = pushableTiles [i].position;
		}
	}

	void OnTriggerEnter() {
		for (int i = 0; i < pushableTiles.Length; i++) {
			pushableTiles [i].position = locations [i];
			pushableTiles [i].GetComponent<PushableTile> ().pushed = false;
		}
	}
}
