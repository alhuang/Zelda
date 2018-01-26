using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour {

	public GameObject boomerang;
	public float boomerang_speed;
	public float time_between_attacks = 5f;
	Enemy_Movement enemyMovement;
	string direction_facing = "South";
	bool canSpawnBoomerang = true;
	float deltaTime = 0;

	// Use this for initialization
	void Start () {
		enemyMovement = GetComponent<Enemy_Movement>();
		//boomerang = GetComponentInChildren<Boomerang>().gameObject;
		//boomerang.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		direction_facing = enemyMovement.GetDirection();
		deltaTime += Time.deltaTime;
		if (canSpawnBoomerang && deltaTime >= time_between_attacks)
		{
			StartCoroutine(spawnBoomerang());
		}
	}

	void OnEnable()
	{

		enemyMovement = GetComponent<Enemy_Movement>();
		//boomerang = GetComponentInChildren<Boomerang>().gameObject;
		//boomerang.SetActive(false);
		canSpawnBoomerang = true;
		StartCoroutine(spawnBoomerang());
		
	}

	IEnumerator spawnBoomerang()
	{
		//boomerang.GetComponent<Boomerang>().SetCurrentPosition(this.transform.position);
		//enemyMovement.SetCanMove(false);
		//deltaTime = 0;
		//canSpawnBoomerang = false;
		//boomerang.SetActive(true);
		//if (direction_facing == "South")
		//{
		//	boomerang.transform.localPosition = new Vector3(0f, -0.25f);
		//	boomerang.GetComponent<Rigidbody>().velocity = new Vector2(0f, -1f) * boomerang_speed;
		//}
		//else if (direction_facing == "North")
		//{
		//	boomerang.transform.localPosition = new Vector3(0f, 0.25f);
		//	boomerang.GetComponent<Rigidbody>().velocity = new Vector2(0f, 1f) * boomerang_speed;
		//}
		//else if (direction_facing == "East")
		//{
		//	boomerang.transform.localPosition = new Vector3(0.25f, 0f);
		//	boomerang.GetComponent<Rigidbody>().velocity = new Vector2(1f, 0f) * boomerang_speed;
		//}
		//else if (direction_facing == "West")
		//{
		//	boomerang.transform.localPosition = new Vector3(-0.25f, 0f);
		//	boomerang.GetComponent<Rigidbody>().velocity = new Vector2(-1f, 0f) * boomerang_speed;
		//}



		enemyMovement.SetCanMove(false);
		deltaTime = 0;
		Debug.Log("Spawning boomerang");
		GameObject newBoomerang = null;
		canSpawnBoomerang = false;
		if (direction_facing == "South")
		{
			newBoomerang = Instantiate(boomerang, new Vector3(this.transform.position.x, this.transform.position.y - .75f), Quaternion.Euler(0f, 0f, 180f));
			newBoomerang.GetComponent<Rigidbody>().velocity = new Vector2(0f, -1f) * boomerang_speed;
		}
		else if (direction_facing == "North")
		{
			newBoomerang = Instantiate(boomerang, new Vector3(this.transform.position.x, this.transform.position.y + .75f), Quaternion.Euler(0f, 0f, 0f));
			newBoomerang.GetComponent<Rigidbody>().velocity = new Vector2(0f, 1f) * boomerang_speed;
		}
		else if (direction_facing == "East")
		{
			newBoomerang = Instantiate(boomerang, new Vector3(this.transform.position.x + .75f, this.transform.position.y), Quaternion.Euler(0f, 0f, 270f));
			newBoomerang.GetComponent<Rigidbody>().velocity = new Vector2(1f, 0f) * boomerang_speed;
		}
		else if (direction_facing == "West")
		{
			newBoomerang = Instantiate(boomerang, new Vector3(this.transform.position.x - .75f, this.transform.position.y), Quaternion.Euler(0f, 0f, 90f));
			newBoomerang.GetComponent<Rigidbody>().velocity = new Vector2(-1f, 0f) * boomerang_speed;
		}
		while (newBoomerang != null)
		{
			yield return null;
		}

		enemyMovement.SetCanMove(true);
		canSpawnBoomerang = true;
	}
}
