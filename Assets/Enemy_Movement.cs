using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

	Rigidbody rb;
	public float movement_speed = 4;
	float deltaTime = 1;
	float horizontal = 0f;
	float vertical = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (deltaTime <= 0)
		{
			horizontal = Random.Range(-1, 2);
			vertical = Random.Range(-1, 2);

			if (Mathf.Abs(horizontal) > 0.0f)
				vertical = 0.0f;

			Vector2 current_input = new Vector2(horizontal, vertical);
			rb.velocity = current_input * movement_speed;
			deltaTime = 1;
		}

		deltaTime -= Time.deltaTime;
	}
}
