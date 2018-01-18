﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public GameObject sword;
	public GameObject arrow;
	public float arrowSpeed = 5;
	public float swordProjectileSpeed = 5;
	ArrowKeyMovement arrowKeyMovement;
	Inventory inventory;
	Health health;
	private string direction_facing = "South";
	private bool canSpawnSword = true;
	private bool canSpawnSwordProjectile = true;
	private bool canSpawnArrow = true;

	// Use this for initialization
	void Start () {
		arrowKeyMovement = GetComponent<ArrowKeyMovement>();
		health = GetComponent<Health>();
		inventory = GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		direction_facing = arrowKeyMovement.GetDirection();
		//Debug.Log(canSpawnSwordProjectile);

		if (Input.GetKeyDown(KeyCode.X) && canSpawnSwordProjectile && health.GetHealth() == health.GetMaxHealth())
		{
			StartCoroutine("spawnSwordProjectile");
		}
		else if (Input.GetKeyDown(KeyCode.X) && canSpawnSword)
		{
			StartCoroutine("spawnSword");
		}
		if (Input.GetKeyDown(KeyCode.Z) && canSpawnArrow && inventory.GetRupees() > 0)
		{
			StartCoroutine("spawnArrow");
		}
	}

	IEnumerator spawnSword()
	{
		Debug.Log("Spawning sword");
		GameObject newSword = null;
		canSpawnSword = false;
		if (direction_facing == "South")
		{
			newSword = Instantiate(sword, new Vector3(this.transform.position.x, this.transform.position.y - .75f), Quaternion.Euler(0f, 0f, 180f));
		}
		else if (direction_facing == "North")
		{
			newSword = Instantiate(sword, new Vector3(this.transform.position.x, this.transform.position.y + .75f), Quaternion.Euler(0f, 0f, 0f));
		}
		else if (direction_facing == "East")
		{
			newSword = Instantiate(sword, new Vector3(this.transform.position.x + .75f, this.transform.position.y), Quaternion.Euler(0f, 0f, 270f));
		}
		else if (direction_facing == "West")
		{
			newSword = Instantiate(sword, new Vector3(this.transform.position.x - .75f, this.transform.position.y), Quaternion.Euler(0f, 0f, 90f));
		}
		arrowKeyMovement.SetCanMove(false);
		yield return new WaitForSeconds(.5f);

		Destroy(newSword);
		arrowKeyMovement.SetCanMove(true);
		canSpawnSword = true;
	}

	IEnumerator spawnSwordProjectile()
	{
		Debug.Log("Spawning sword projectile");
		GameObject newSwordProjectile = null;
		canSpawnSwordProjectile = false;
		if (direction_facing == "South")
		{
			newSwordProjectile = (GameObject)Instantiate(sword, new Vector3(this.transform.position.x, this.transform.position.y - .75f), Quaternion.Euler(0f, 0f, 180f));
			newSwordProjectile.GetComponent<Rigidbody>().velocity = new Vector2(0f, -1f) * swordProjectileSpeed;
		}
		else if (direction_facing == "North")
		{
			newSwordProjectile = (GameObject)Instantiate(sword, new Vector3(this.transform.position.x, this.transform.position.y + .75f), Quaternion.Euler(0f, 0f, 0f));
			newSwordProjectile.GetComponent<Rigidbody>().velocity = new Vector2(0f, 1f) * swordProjectileSpeed;
		}
		else if (direction_facing == "East")
		{
			newSwordProjectile = (GameObject)Instantiate(sword, new Vector3(this.transform.position.x + .75f, this.transform.position.y), Quaternion.Euler(0f, 0f, 270f));
			newSwordProjectile.GetComponent<Rigidbody>().velocity = new Vector2(1f, 0f) * swordProjectileSpeed;
		}
		else if (direction_facing == "West")
		{
			newSwordProjectile = (GameObject)Instantiate(sword, new Vector3(this.transform.position.x - .75f, this.transform.position.y), Quaternion.Euler(0f, 0f, 90f));
			newSwordProjectile.GetComponent<Rigidbody>().velocity = new Vector2(-1f, 0f) * swordProjectileSpeed;
		}
		yield return new WaitForSeconds(1f);
		canSpawnSwordProjectile = true;
	}

	IEnumerator spawnArrow()
	{
		inventory.AddRupees(-1);
		GameObject newArrow= null;
		canSpawnArrow = false;
		if (direction_facing == "South")
		{
			newArrow = (GameObject)Instantiate(arrow, new Vector3(this.transform.position.x, this.transform.position.y - .75f), Quaternion.Euler(0f, 0f, 180f));
			newArrow.GetComponent<Rigidbody>().velocity = new Vector2(0f, -1f) * arrowSpeed;
		}
		else if (direction_facing == "North")
		{
			newArrow = (GameObject)Instantiate(arrow, new Vector3(this.transform.position.x, this.transform.position.y + .75f), Quaternion.Euler(0f, 0f, 0f));
			newArrow.GetComponent<Rigidbody>().velocity = new Vector2(0f, 1f) * arrowSpeed;
		}
		else if (direction_facing == "East")
		{
			newArrow = (GameObject)Instantiate(arrow, new Vector3(this.transform.position.x + .75f, this.transform.position.y), Quaternion.Euler(0f, 0f, 270f));
			newArrow.GetComponent<Rigidbody>().velocity = new Vector2(1f, 0f) * arrowSpeed;
		}
		else if (direction_facing == "West")
		{
			newArrow = (GameObject)Instantiate(arrow, new Vector3(this.transform.position.x - .75f, this.transform.position.y), Quaternion.Euler(0f, 0f, 90f));
			newArrow.GetComponent<Rigidbody>().velocity = new Vector2(-1f, 0f) * arrowSpeed;
		}
		yield return new WaitForSeconds(1f);
		canSpawnArrow = true;
	}

	public void SetCanSpawnSwordProjectile(bool change)
	{
		canSpawnSwordProjectile = change;
	}
}
