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

	IEnumerator Move()
	{
		isMoving = true;
		horizontal = Random.Range(-1, 2);
		vertical = Random.Range(-1, 2);

		if (Mathf.Abs(horizontal) > 0.0f)
			vertical = 0.0f;

		Vector2 current_input = new Vector2(horizontal, vertical);
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
}
