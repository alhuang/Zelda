﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0)
		{
			//attack.SetCanSpawnSwordProjectile(true);
			//Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("onTriggerEnter");
		if (other.gameObject.tag == "enemy")
		{
			Health enemy_hp = other.GetComponent<Health>();
			enemy_hp.SubtractHealth(2f);
			Debug.Log(enemy_hp.GetHealth());
			//attack.SetCanSpawnSwordProjectile(true);
			Destroy(gameObject);
		}
		if (other.gameObject.tag == "wall")
		{
			Destroy(gameObject);
		}

		//if (other.gameObject.tag != "Link" && other.gameObject.tag != "rupee" && other.gameObject.tag != "heart")
		//	Destroy(gameObject);
	}
}
