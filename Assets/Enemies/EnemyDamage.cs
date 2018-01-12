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
		Health linkHealth = other.GetComponent<Health> ();

		if (linkHealth == null) {
			return;
		}
		linkHealth.SubtractHealth (damageAmount);
	}

}