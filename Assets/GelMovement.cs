using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelMovement : MonoBehaviour {

	public float movement_speed = 1f;
	Rigidbody rb;
	float horizontal = 0f;
	float vertical = 0f;
	bool isMoving = false;
	

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isMoving)
		{
			StartCoroutine(Move());
		}
		
	}

	void OnEnable()
	{
		rb = GetComponent<Rigidbody>();
		StartCoroutine(Move());
	}

	IEnumerator Move()
	{
		isMoving = true;
		//horizontal = Random.Range(-1, 2);
		//vertical = Random.Range(-1, 2);

		//if (Mathf.Abs(horizontal) > 0.0f)
		//	vertical = 0.0f;

		Vector2 current_input = Vector2.zero;
		string direction = "South";


		Hashtable raycasts = new Hashtable();
		raycasts["East"] = Physics.Raycast(transform.position, transform.right, .6f, LayerMask.NameToLayer("EnemyMovementRayCasts"));
		raycasts["South"] = Physics.Raycast(transform.position, -transform.up, .6f, LayerMask.NameToLayer("EnemyMovementRayCasts"));
		raycasts["West"] = Physics.Raycast(transform.position, -transform.right, .6f, LayerMask.NameToLayer("EnemyMovementRayCasts"));
		raycasts["North"] = Physics.Raycast(transform.position, transform.up, .6f, LayerMask.NameToLayer("EnemyMovementRayCasts"));
		string nextDirection = GetNextDirection();
		bool directionOk = false;
		while (!directionOk)
		{
			if ((bool)raycasts[nextDirection])
			{
				nextDirection = GetNextDirection();
			}
			else
			{
				directionOk = true;
			}
		}


		if (nextDirection == "East")
		{
			current_input = new Vector2(1, 0);
		}
		else if (nextDirection == "South")
		{
			current_input = new Vector2(0, -1);
		}
		else if (nextDirection == "West")
		{
			current_input = new Vector2(-1, 0);
		}
		else
		{
			current_input = new Vector2(0, 1);
		}
		direction = nextDirection;

		//Vector2 current_input = new Vector2(horizontal, vertical);
		rb.velocity = current_input * movement_speed;

		yield return new WaitForSeconds(1f / movement_speed);
		rb.velocity = Vector2.zero;
		AdjustPosition();
		yield return new WaitForSeconds(1f);
		isMoving = false;
	}

	void AdjustPosition()
	{
		float x = transform.position.x;
		float y = transform.position.y;
		if (x % 1 >= 0.5)
		{
			x = Mathf.Ceil(x);
		}
		else
		{
			x = Mathf.Floor(x);
		}
		if (y % 1 >= 0.5)
		{
			y = Mathf.Ceil(y);
		}
		else
		{
			y = Mathf.Floor(y);
		}

		transform.position = new Vector3(x, y);
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

}
