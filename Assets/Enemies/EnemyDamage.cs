using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
	public float damageAmount = .5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			Health linkHealth = other.GetComponent<Health> ();
			if (!linkHealth.invincible)
			{
				Vector3 direction = (other.transform.position -
					this.transform.position).normalized;
				linkHealth.SubtractHealth(damageAmount);
				StartCoroutine(other.GetComponent<Health>().PushBackDir(direction));
			}
		}
	}

}