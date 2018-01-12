using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

	public Attack attack;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("Alive");
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("onTriggerEnter");
		if (other.gameObject.tag == "enemy")
			Debug.Log("lower enemy hp");
		if (other.gameObject.tag != "Link" && other.gameObject.tag != "rupee" && other.gameObject.tag != "heart")
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collider other)
	{
		attack.SetCanSpawnSwordProjectile(true);
		Destroy(gameObject);
	}

}
