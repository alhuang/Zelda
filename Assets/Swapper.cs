using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour {
	public GameObject Link;

	private bool collided = false;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0)
		{
			//attack.SetCanSpawnSwordProjectile(true);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("onTriggerEnter");
		if (other.gameObject.tag == "enemy") {
			if (collided) {
				return;
			}
			collided = true;

			SwapLocations (other);
			Health enemy_hp = other.GetComponent<Health> ();
			enemy_hp.SubtractHealth (1f);
			Debug.Log (enemy_hp.GetHealth ());
			//attack.SetCanSpawnSwordProjectile(true);
			Destroy (gameObject);
		} else if (other.gameObject.tag == "SwapperStopper") {
			Destroy (gameObject);
		}

		//if (other.gameObject.tag != "Link" && other.gameObject.tag != "rupee" && other.gameObject.tag != "heart")
		//	Destroy(gameObject);
	}

	void SwapLocations(Collider other) {
		Debug.Log ("this ran");
		Vector3 otherPos = other.transform.position;
		Vector3 linkPos = Link.transform.position;
		other.transform.position = Vector3.zero;
		Link.transform.position = otherPos;
		other.transform.position = linkPos;
	}
}
