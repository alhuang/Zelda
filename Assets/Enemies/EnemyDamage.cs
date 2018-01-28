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

	void OnTriggerStay(Collider other) {
		if (other.tag == "Link") {
			Health linkHealth = other.GetComponent<Health> ();
			if (!linkHealth.invincible)
			{
				Vector3 directionVector = (other.transform.position -
					this.transform.position).normalized;

				linkHealth.SubtractHealth(damageAmount);
				other.GetComponent<Health>().callPushBackDir(directionVector);
				StartCoroutine(other.GetComponent<InputToAnimator>().StopAnimations(1f));
			}
		}
	}

}
