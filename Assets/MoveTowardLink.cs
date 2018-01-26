using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardLink : MonoBehaviour {

	public GameObject Link;
	public float movementSpeed = 2f;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 directionVector = Link.transform.position - transform.position;

		float xDir = 0;
		float yDir = 0;
		float zDir = 0;

		float x = Mathf.Abs(directionVector.x);
		float y = Mathf.Abs(directionVector.y);

		if (Mathf.Max (x, y) == x) {
			xDir = 1f;
			if (directionVector.x < 0) {
				xDir *= -1;
			}
		} else {
			yDir = 1f;
			if (directionVector.y < 0) {
				yDir *= -1;
			}
		}

		Vector3 direction = new Vector3 (xDir, yDir, zDir);

		rb.velocity = direction * movementSpeed;
	}

	void flipDirection () {
		movementSpeed *= -1f;
	}
}
