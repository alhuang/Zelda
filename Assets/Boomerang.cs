﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {

	Vector3 start_position;
	Vector3 return_position;
	Rigidbody rb;
	public float distance = 5f;
	bool returning = false;
	Enemy_Movement enemyMovement;
	bool Link = false;
	public float speed = 5;
	//public Attack attack;

	// Use this for initialization
	void Start () {
		start_position = transform.position;
		return_position = transform.position;
		rb = GetComponent<Rigidbody>();
		StartCoroutine(SpinAnimation());
		//StartCoroutine(SlowDown());
		//enemyMovement = GetComponentInParent<Enemy_Movement>();
		//attack = GetComponent<Attack>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		//duration += Time.deltaTime;
		Vector3 currentPosition = this.transform.position;
		//Debug.Log(start_position.ToString());

		if (screenPosition.y > Screen.height - 80 || screenPosition.y < 15 || screenPosition.x > Screen.width - 15 || screenPosition.x < 15)
		{
			rb.velocity = -rb.velocity;

			returning = true;
		}
		if (returning && currentPosition.x <= start_position.x + .5 && currentPosition.x >= start_position.x - .5 &&
			currentPosition.y <= start_position.y + .5 && currentPosition.y >= start_position.y - .5)
		{
			Debug.Log("Start position:" + start_position.ToString());
			Debug.Log("Current position:" + currentPosition.ToString());
			Debug.Log(returning.ToString());
			if (!Link)
			{
				Destroy(gameObject);
			}
			if (enemyMovement != null)
			{
				//enemyMovement.SetCanMove(true);
				//gameObject.SetActive(false);
				returning = false;
				Destroy(gameObject);
			}
			//returning = false;

			
		}

		if (!returning && (currentPosition.x <= start_position.x - distance || currentPosition.x >= start_position.x + distance ||
			currentPosition.y <= start_position.y - distance || currentPosition.y >= start_position.y + distance))
		{
			Debug.Log("returning");
			rb.velocity = -rb.velocity;
			returning = true;
		}

		if (returning && Link)
		{
			rb.velocity = new Vector3(return_position.x - this.transform.position.x, return_position.y - this.transform.position.y).normalized * speed;
		}
	}

	IEnumerator SlowDown()
	{
		//rb.velocity = Vector3.Lerp(rb.velocity * 0f, rb.velocity, 1.0f - 10 * Time.deltaTime);
		//yield return null;
		rb.velocity = rb.velocity * 0.8f;
		yield return new WaitForSeconds(0.1f);
		rb.velocity = rb.velocity * 0.8f;
		yield return new WaitForSeconds(0.1f);
		rb.velocity = rb.velocity * 0.8f;
		yield return new WaitForSeconds(0.1f);
		rb.velocity = rb.velocity * 0.8f;
		yield return new WaitForSeconds(0.1f);
		rb.velocity = rb.velocity * 0.8f;
	}

	IEnumerator SpinAnimation()
	{
		while (true)
		{
			transform.Rotate(0f, 0f, 90f);
			yield return new WaitForSeconds(0.1f);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Link" && !Link)
		{
			Health enemy_hp = other.GetComponent<Health>();
			enemy_hp.SubtractHealth(1f);
			Debug.Log(enemy_hp.GetHealth());
			// Destroy(gameObject);
		}
		if (!returning && other.gameObject.tag == "enemy")
		{
			returning = true;
			rb.velocity = -rb.velocity;
			if (other.gameObject.name.Contains("Keese") || other.gameObject.name.Contains("Gel"))
			{
				Health enemy_hp = other.GetComponent<Health>();
				enemy_hp.SubtractHealth(1f);
			}

		}
		if (returning && other.gameObject.tag == "Link" && Link)
		{
			Destroy(gameObject);
			returning = false;
		}


		//if (other.gameObject.tag != "Link" && other.gameObject.tag != "rupee" && other.gameObject.tag != "heart")
		//	Destroy(gameObject);
	}


	public void SetCurrentPosition(Vector3 position)
	{
		start_position = position;
	}

	public void SetReturnPosition(Vector3 position)
	{
		return_position = position;
	}

	public void SetLink(bool change)
	{
		Link = change;
	}
}
