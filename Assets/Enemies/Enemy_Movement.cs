using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

	Rigidbody rb;
	public float movement_speed = 4;
	public float time_between_mvmt_changes = 1;
	float horizontal = 0f;
	float vertical = 0f;
	bool changeDirection = true;
	string direction = "South";

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (changeDirection)
		{
			StartCoroutine("Move");
		}
	}

	IEnumerator Move()
	{
		changeDirection = false;
		horizontal = Random.Range(-1, 2);
		vertical = Random.Range(-1, 2);

		if (Mathf.Abs(horizontal) > 0.0f)
			vertical = 0.0f;

		Vector2 current_input = new Vector2(horizontal, vertical);
		rb.velocity = current_input * movement_speed;
		string prevDirection = direction;
		//save user direction
		if (current_input[0] > 0f)
		{
			direction = "East";
		}
		else if (current_input[0] < 0f)
		{
			direction = "West";
		}
		else if (current_input[1] > 0f)
		{
			direction = "North";
		}
		else if (current_input[1] < 0f)
		{
			direction = "South";
		}


		//if direction change, align enemy
		if (direction != prevDirection)
		{
			if (direction == "North" || direction == "South")
			{
				float positionFromCenter = (transform.position.x - Mathf.Floor(transform.position.x));
				if (positionFromCenter < .25f)
				{
					transform.position = new Vector3(transform.position.x - positionFromCenter,
						transform.position.y, transform.position.z);

				}
				else if (positionFromCenter >= .75f)
				{
					transform.position = new Vector3(transform.position.x + (1 - positionFromCenter),
						transform.position.y, transform.position.z);
				}
				else
				{

					float correctionAmount = .5f - positionFromCenter;
					transform.position = new Vector3(transform.position.x + correctionAmount,
						transform.position.y, transform.position.z);
				}
			}
			else
			{ //going east or west
				float positionFromCenter = (transform.position.y - Mathf.Floor(transform.position.y));
				if (positionFromCenter < .25f)
				{
					transform.position = new Vector3(transform.position.x,
						transform.position.y - positionFromCenter, transform.position.z);

				}
				else if (positionFromCenter >= .75f)
				{
					transform.position = new Vector3(transform.position.x,
						transform.position.y + (1 - positionFromCenter), transform.position.z);
				}
				else
				{

					float correctionAmount = .5f - positionFromCenter;
					transform.position = new Vector3(transform.position.x,
						transform.position.y + correctionAmount, transform.position.z);
				}
			}
		}

		yield return new WaitForSeconds(time_between_mvmt_changes);
		changeDirection = true;
	}
}
