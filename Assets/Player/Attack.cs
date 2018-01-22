using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {

	public GameObject sword;
	public GameObject arrow;
	public GameObject boomerang;
	public float arrowSpeed = 5;
	public float swordProjectileSpeed = 5;
	public float boomerang_speed = 5;
	public string AWeapon = "Sword";
	public string BWeapon = "";
	public Sprite[] UISprites;
	public GameObject WeaponUI;
	public bool hasBow = false;
	public bool hasBoomerang = false;
	//Bow, Boomerang, Bomb

	private ArrowKeyMovement arrowKeyMovement;
	private Inventory inventory;
	private Health health;
	private string direction_facing = "South";
	private bool canSpawnSword = true;
	private bool canSpawnSwordProjectile = true;
	private bool canSpawnBattack = true;
	private string[] weapons;

	// Use this for initialization
	void Start () {
		arrowKeyMovement = GetComponent<ArrowKeyMovement>();
		health = GetComponent<Health>();
		inventory = GetComponent<Inventory>();
		//boomerang = GetComponentInChildren<Boomerang>().gameObject;
		//boomerang.SetActive(false);

		weapons = new string[3];
		weapons [0] = "Bow";
		weapons [1] = "Boomerang";
		weapons [2] = "Bomb";
		//BWeapon = "";
	}
	
	// Update is called once per frame
	void Update () {
		direction_facing = arrowKeyMovement.GetDirection();
		//Debug.Log(canSpawnSwordProjectile);

		if (Input.GetKeyDown(KeyCode.X) && canSpawnSwordProjectile &&
			health.GetHealth() == health.GetMaxHealth() &&
			AWeapon == "Sword")
		{
			StartCoroutine("spawnSwordProjectile");
		}
		else if (Input.GetKeyDown(KeyCode.X) && canSpawnSword &&
			AWeapon == "Sword")
		{
			StartCoroutine("spawnSword");
		}
		if (Input.GetKeyDown (KeyCode.Z) && canSpawnBattack && inventory.GetRupees () > 0 &&
			BWeapon == weapons [0]) {
			StartCoroutine ("spawnArrow");
		} else if (Input.GetKeyDown (KeyCode.Z) && canSpawnBattack && BWeapon == weapons [1]) {
			Debug.Log("Boomerang");
			StartCoroutine (spawnBoomerang ());

		//2, 3, 4 used to switch B weapons
		//2 = bow, 3 = boomerang, 4 = bomb
		//update equipped
		//change sprite on top
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if (hasBow) {
				SetBWeapon (weapons [0]);
				WeaponUI.GetComponent<Image> ().sprite = UISprites [0];
			}
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if (hasBoomerang) {
				SetBWeapon (weapons [1]);
				WeaponUI.GetComponent<Image> ().sprite = UISprites [1];
			}
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			if (inventory.GetBombs () > 0) {
				SetBWeapon (weapons [2]);
				WeaponUI.GetComponent<Image> ().sprite = UISprites [2];
			}
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
		yield return new WaitForSeconds(1f);
		canSpawnBattack = true;
	}

	IEnumerator spawnBoomerang()
	{

		//boomerang.GetComponent<Boomerang>().SetCurrentPosition(this.transform.position);
		//arrowKeyMovement.SetCanMove(false);
		GameObject newBoomerang = null;
		canSpawnBattack = false;
		//boomerang.SetActive(true);
		if (direction_facing == "South")
		{
			newBoomerang = (GameObject)Instantiate(boomerang, new Vector3(this.transform.position.x, this.transform.position.y - .25f), Quaternion.Euler(0f, 0f, 180f));
			//boomerang.transform.localPosition = new Vector3(0f, -0.25f);
			newBoomerang.GetComponent<Rigidbody>().velocity = new Vector2(0f, -1f) * boomerang_speed;
		}
		else if (direction_facing == "North")
		{
			newBoomerang = (GameObject)Instantiate(boomerang, new Vector3(this.transform.position.x, this.transform.position.y + .25f), Quaternion.Euler(0f, 0f, 180f));
			//boomerang.transform.localPosition = new Vector3(0f, 0.25f);
			newBoomerang.GetComponent<Rigidbody>().velocity = new Vector2(0f, 1f) * boomerang_speed;
		}
		else if (direction_facing == "East")
		{
			newBoomerang = (GameObject)Instantiate(boomerang, new Vector3(this.transform.position.x + .25f, this.transform.position.y), Quaternion.Euler(0f, 0f, 180f));
			//boomerang.transform.localPosition = new Vector3(0.25f, 0f);
			newBoomerang.GetComponent<Rigidbody>().velocity = new Vector2(1f, 0f) * boomerang_speed;
		}
		else if (direction_facing == "West")
		{
			newBoomerang = (GameObject)Instantiate(boomerang, new Vector3(this.transform.position.x - .25f, this.transform.position.y), Quaternion.Euler(0f, 0f, 180f));
			//boomerang.transform.localPosition = new Vector3(-0.25f, 0f);
			newBoomerang.GetComponent<Rigidbody>().velocity = new Vector2(-1f, 0f) * boomerang_speed;
		}
		newBoomerang.GetComponent<Boomerang>().SetLink(true);
		newBoomerang.GetComponent<Boomerang>().speed = boomerang_speed;
		StartCoroutine(sendPositionToBoomerang(newBoomerang));
		yield return null;

	}

	IEnumerator sendPositionToBoomerang(GameObject boom)
	{
		while (boom != null)
		{
			boom.GetComponent<Boomerang>().SetReturnPosition(this.transform.position);
			yield return null;
		}
		canSpawnBattack = true;

	}

	public void SetCanSpawnBAttack(bool change)
	{
		canSpawnBattack = change;
	}

	public void SetCanSpawnSwordProjectile(bool change)
	{
		canSpawnSwordProjectile = change;
	}

	public void SetAWeapon(string weapon) {
		AWeapon = weapon;
	}

	public void SetBWeapon(string weapon) {
		BWeapon = weapon;
	}
}
