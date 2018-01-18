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
				Vector3 directionVector = (other.transform.position -
					this.transform.position).normalized;
				float xDir = 0;
				float yDir = 0;
				float zDir = 0;

				float x = Mathf.Abs(directionVector.x);
				float y = Mathf.Abs(directionVector.x);
				float z = Mathf.Abs(directionVector.x);

				if (Mathf.Max (x, y, z) == x) {
					xDir = 1f;
				} else if (Mathf.Max (x, y, z) == y) {
					yDir = 1f;
				} else {
					zDir = 1f;
				}

				Vector3 direction = new Vector3 (xDir, yDir, zDir);

				linkHealth.SubtractHealth(damageAmount);
				StartCoroutine(other.GetComponent<Health>().PushBackDir(direction));
			}
		}
	}

}