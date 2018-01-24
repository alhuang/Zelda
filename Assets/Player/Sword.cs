using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

	public Attack attack;

	public Sprite smallBoom;
	public Sprite bigBoom;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height - 80 || screenPosition.y < 15 || screenPosition.x > Screen.width - 15 || screenPosition.x < 15)
		{
			//attack.SetCanSpawnSwordProjectile(true);
			StartCoroutine(DestroySelf());
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("onTriggerEnter");
		if (other.gameObject.tag == "enemy")
		{
			Health enemy_hp = other.GetComponent<Health>();
			enemy_hp.SubtractHealth(1f);
			enemy_hp.callPushBackDir (-(transform.position -
				other.transform.position).normalized);
			Debug.Log(enemy_hp.GetHealth());
			//attack.SetCanSpawnSwordProjectile(true);
			StartCoroutine(DestroySelf());
		}
			
		//if (other.gameObject.tag != "Link" && other.gameObject.tag != "rupee" && other.gameObject.tag != "heart")
		//	Destroy(gameObject);
	}

	IEnumerator DestroySelf() {
		GetComponent<SpriteRenderer> ().sprite = smallBoom;
		yield return new WaitForSeconds (.1f);
		GetComponent<SpriteRenderer> ().sprite = bigBoom;
		yield return new WaitForSeconds (.1f);


		Destroy (gameObject);
	}

}
