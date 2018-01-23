using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairsTeleport : MonoBehaviour {
	public GameObject Camera;

	public float linkX;
	public float linkY;

	public float cameraX;
	public float cameraY;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			Camera.transform.position += new Vector3 (cameraX, cameraY, 0);
			other.transform.position = new Vector3 (linkX, linkY, 0);
		}
	}
}
