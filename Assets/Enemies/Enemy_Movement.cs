﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

	Rigidbody rb;
	public float movement_speed = 4;
	public float time_between_mvmt_changes = 1;
	public bool is_Keese = false;
	float horizontal = 0f;
	float vertical = 0f;
	bool changeDirection = true;
	bool canMove = true;
	string direction = "South";
	float timeToStop = 5f;
	float restTime = 2f;
	float timer = 0f;
	Animator animator;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		timeToStop = Random.Range(3f, 7f);
	}

	public float GetMovementSpeed() {
		return movement_speed;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (changeDirection && canMove)
		{
			StartCoroutine("Move");
		}
		if (is_Keese && timer >= timeToStop && timer <= timeToStop + restTime)
		{
			canMove = false;
			animator.speed = 0.0f;
		}
		if (is_Keese && timer >= timeToStop + restTime)
		{
			canMove = true;
			animator.speed = 1.0f;
			timer = 0f;
			timeToStop = Random.Range(3f, 7f);
			restTime = Random.Range(1f, 3f);
		}
		if (!canMove)
		{
			StopCoroutine(Move());
			changeDirection = true;
			rb.velocity = Vector2.zero;
		}
	}

	void OnEnable()
	{
		rb = GetComponent<Rigidbody>();
		StartCoroutine(Move());
	}

	IEnumerator Move()
	{
		string prevDirection = direction;
		changeDirection = false;
		Vector2 current_input = Vector2.zero;
		if (is_Keese)
		{
			horizontal = Random.Range(-1, 2);
			vertical = Random.Range(-1, 2);
			current_input = new Vector2(horizontal, vertical);
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
		}
		else
		{

			//if (Mathf.Abs(horizontal) > 0.0f && !is_Keese)
			//	vertical = 0.0f;


			Hashtable raycasts = new Hashtable();
			raycasts["East"] = Physics.Raycast(transform.position, transform.right, .6f, LayerMask.NameToLayer("EnemyMovementRayCasts"));
			raycasts["South"] = Physics.Raycast(transform.position, -transform.up, .6f, LayerMask.NameToLayer("EnemyMovementRayCasts"));
			raycasts["West"] = Physics.Raycast(transform.position, -transform.right, .6f, LayerMask.NameToLayer("EnemyMovementRayCasts"));
			raycasts["North"] = Physics.Raycast(transform.position, transform.up, .6f, LayerMask.NameToLayer("EnemyMovementRayCasts"));
			string nextDirection = GetNextDirection();
			for (int i = 0; i < 100; i++) {
				if ((bool)raycasts[nextDirection])
				{
					nextDirection = GetNextDirection();
				}
				else
				{
					i = 100;
				}
			}


			if (nextDirection == "East")
			{
				horizontal = 1f;
				vertical = 0f;
				current_input = new Vector2(1, 0);
			}
			else if (nextDirection == "South")
			{
				vertical = -1f;
				horizontal = 0f;
				current_input = new Vector2(0, -1);
			}
			else if (nextDirection == "West")
			{
				horizontal = -1f;
				vertical = 0f;
				current_input = new Vector2(-1, 0);
			}
			else
			{
				vertical = 1f;
				horizontal = 0f;
				current_input = new Vector2(0, 1);
			}
			direction = nextDirection;
		}
		//Vector2 current_input = new Vector2(horizontal, vertical);
		rb.velocity = current_input * movement_speed;
		



		//if direction change, align enemy
		if (direction != prevDirection)
		{
			if (direction == "North" || direction == "South")
			{
				float positionFromCenter = (transform.position.x - Mathf.Floor(transform.position.x));
				if (positionFromCenter < .5f)
				{
					transform.position = new Vector3(transform.position.x - positionFromCenter,
						transform.position.y, transform.position.z);

				}
				else if (positionFromCenter >= .5f)
				{
					transform.position = new Vector3(transform.position.x + (1 - positionFromCenter),
						transform.position.y, transform.position.z);
				}
				else
				{

					float correctionAmount = 1f - positionFromCenter;
					transform.position = new Vector3(transform.position.x + correctionAmount,
						transform.position.y, transform.position.z);
				}
			}
			else
			{ //going east or west
				float positionFromCenter = (transform.position.y - Mathf.Floor(transform.position.y));
				if (positionFromCenter < .5f)
				{
					transform.position = new Vector3(transform.position.x,
						transform.position.y - positionFromCenter, transform.position.z);

				}
				else if (positionFromCenter >= .5f)
				{
					transform.position = new Vector3(transform.position.x,
						transform.position.y + (1 - positionFromCenter), transform.position.z);
				}
				else
				{

					float correctionAmount = 1f - positionFromCenter;
					transform.position = new Vector3(transform.position.x,
						transform.position.y + correctionAmount, transform.position.z);
				}
			}
		}

		yield return new WaitForSeconds(time_between_mvmt_changes);
		changeDirection = true;
	}

	string GetNextDirection()
	{
		int rand = Random.Range(0, 4);
		if (rand == 0)
		{
			return "East";
		}
		else if (rand == 1)
		{
			return "South";
		}
		else if (rand == 2)
		{
			return "West";
		}
		return "North";
	}


	public string GetDirection()
	{
		return direction;
	}

	public void SetCanMove(bool change)
	{
		canMove = change;
	}

	public float GetHorizontal()
	{
		return horizontal;
	}

	public float GetVertical()
	{
		return vertical;
	}
}
