﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwapperAttack : MonoBehaviour {

	public GameObject arrow;
	public float arrowSpeed = 5;
	//Bow, Boomerang, Bomb
	public bool hasSwapper = false;
	public AudioClip discovery;

	private ArrowKeyMovement arrowKeyMovement;
	private Health health;
	private InputToAnimator animator;
	private string direction_facing = "South";
	private bool canSpawnBattack = true;
	private Animator anim;

	public GameObject AWeaponUI;
	public Sprite AWeaponSprite;

	// Use this for initialization
	void Start () {
		arrowKeyMovement = GetComponent<ArrowKeyMovement>();
		health = GetComponent<Health>();
		animator = GetComponent<InputToAnimator>();
		//boomerang = GetComponentInChildren<Boomerang>().gameObject;
		//boomerang.SetActive(false);
		anim = GetComponent<Animator>();
		//BWeapon = "";
	}

	// Update is called once per frame
	void Update () {
		direction_facing = arrowKeyMovement.GetDirection();
		//Debug.Log(canSpawnSwordProjectile);


		if (Input.GetKeyDown(KeyCode.X) && canSpawnBattack && hasSwapper)
		{
			StartCoroutine("spawnArrow");
		} else if (Input.GetKeyDown(KeyCode.Q)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "swapper")
		{
			hasSwapper = true;
			Destroy(other.gameObject);
			AudioSource.PlayClipAtPoint(discovery, Camera.main.transform.position);
			AWeaponUI.GetComponent<Image> ().sprite = AWeaponSprite;
		}
	}



	IEnumerator spawnArrow()
	{
		Debug.Log ("arrowspawned");
		GameObject newArrow= null;
		canSpawnBattack = false;
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
		newArrow.GetComponent<Swapper> ().Link = gameObject;
		yield return new WaitForSeconds(1f);
		canSpawnBattack = true;
	}


	public void SetCanSpawnBAttack(bool change)
	{
		canSpawnBattack = change;
	}
}
