using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardLink : MonoBehaviour {

	public GameObject Link;
	public float movementSpeed = 2f;

	private string direction = "";
	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.C)) {
			movementSpeed *= -1f;
		}
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

		AlignMovement (direction);

		rb.velocity = direction * movementSpeed;
	}

	private void AlignMovement(Vector3 inDirection) {
		Vector2 current_input = inDirection;

		string prevDirection = direction;
		//save user direction
		if (current_input [0] > 0f) {
			direction = "East";
		} else if (current_input [0] < 0f) {
			direction = "West";
		} else if (current_input [1] > 0f) {
			direction = "North";
		} else if (current_input [1] < 0f) {
			direction = "South";
		}


		//if direction change, align link
		if (direction != prevDirection) {
			if (direction == "North" || direction == "South") {
				float positionFromCenter = (transform.position.x - Mathf.Floor (transform.position.x));
				if (positionFromCenter < .25f) {
					transform.position = new Vector3 (transform.position.x - positionFromCenter,
						transform.position.y, transform.position.z);

				} else if (positionFromCenter >= .75f) {
					transform.position = new Vector3 (transform.position.x + (1 - positionFromCenter),
						transform.position.y, transform.position.z);
				} else {

					float correctionAmount = .5f - positionFromCenter;
					transform.position = new Vector3 (transform.position.x + correctionAmount,
						transform.position.y, transform.position.z);
				}
			} else { //going east or west
				float positionFromCenter = (transform.position.y - Mathf.Floor (transform.position.y));
				if (positionFromCenter < .25f) {
					transform.position = new Vector3 (transform.position.x,
						transform.position.y - positionFromCenter, transform.position.z);

				} else if (positionFromCenter >= .75f) {
					transform.position = new Vector3 (transform.position.x,
						transform.position.y + (1 - positionFromCenter), transform.position.z);
				} else {

					float correctionAmount = .5f - positionFromCenter;
					transform.position = new Vector3 (transform.position.x,
						transform.position.y + correctionAmount, transform.position.z);
				}
			}
		}
	}
}
