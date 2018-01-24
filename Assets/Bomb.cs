using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public Sprite explosion;
	bool exploded = false;
	public float detonationTime = 1f;
	public float damage = 4f;

	// Use this for initialization
	void Start () {
		StartCoroutine(Explode());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		if (exploded)
		{
			if (other.tag == "enemy")
			{
				Health enemy_hp = other.GetComponent<Health>();
				enemy_hp.SubtractHealth(damage);
				enemy_hp.callPushBackDir(-(transform.position -
					other.transform.position).normalized);
				Debug.Log(enemy_hp.GetHealth());
				//attack.SetCanSpawnSwordProjectile(true);
				Destroy(gameObject);
			}
		}
	}

	IEnumerator Explode()
	{
		yield return new WaitForSeconds(detonationTime);
		exploded = true;
		this.GetComponent<SpriteRenderer>().sprite = explosion;
		this.GetComponent<Transform>().localScale = new Vector2(4f, 4f);
		yield return new WaitForSeconds(.1f);
		Destroy(gameObject);
	}
}
