using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour {

	Rigidbody rb;
	public float movement_speed = 4;

	private string direction = "South";


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 current_input = GetInput();
		rb.velocity = current_input * movement_speed;

		string prevDirection = direction;
		Debug.Log(current_input);
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

	Vector2 GetInput()
	{
		float horizontal_input = Input.GetAxisRaw("Horizontal");
		float vertical_input = Input.GetAxisRaw("Vertical");

		if (Mathf.Abs(horizontal_input) > 0.0f)
			vertical_input = 0.0f;

		return new Vector2(horizontal_input, vertical_input);
	}

	public string GetDirection()
	{
		return direction;
	}


}
