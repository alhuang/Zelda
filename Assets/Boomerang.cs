using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {

	GameObject parent;
	Vector3 start_position;
	Rigidbody rb;
	public float distance = 5f;
	bool returning = false;
	Enemy_Movement enemyMovement;

	// Use this for initialization
	void Start () {
		start_position = transform.position;
		rb = GetComponent<Rigidbody>();
		enemyMovement = GetComponentInParent<Enemy_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		//duration += Time.deltaTime;
		Vector3 currentPosition = this.transform.position;
		if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0)
		{
			rb.velocity = -rb.velocity;
			//Destroy(gameObject);

			returning = true;
		}
		if (returning && currentPosition.x <= start_position.x + .5 && currentPosition.x >= start_position.x - .5 &&
			currentPosition.y <= start_position.y + .5 && currentPosition.y >= start_position.y - .5)
		{
			Debug.Log("Start position:" + start_position.ToString());
			Debug.Log("Current position:" + currentPosition.ToString());
			Debug.Log(returning.ToString());
			enemyMovement.SetCanMove(true);
			gameObject.SetActive(false);
		}

		if (!returning && (currentPosition.x <= start_position.x - distance || currentPosition.x >= start_position.x + distance ||
			currentPosition.y <= start_position.y - distance || currentPosition.y >= start_position.y + distance))
		{
			rb.velocity = -rb.velocity;
			returning = true;
		}


	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("onTriggerEnter");
		if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Link")
		{
			Health enemy_hp = other.GetComponent<Health>();
			enemy_hp.SubtractHealth(1f);
			Debug.Log(enemy_hp.GetHealth());
			// Destroy(gameObject);
		}

		//if (other.gameObject.tag != "Link" && other.gameObject.tag != "rupee" && other.gameObject.tag != "heart")
		//	Destroy(gameObject);
	}

	public void SetCurrentPosition(Vector3 position)
	{
		start_position = position;
	}
}
