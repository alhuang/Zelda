using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

	public AudioClip rupee_collection_sound_clip;
	public AudioClip heart_sound_clip;
	Inventory inventory;
	Health health;

	// Use this for initialization
	void Start () {
		inventory = GetComponent<Inventory> ();
		health = GetComponent<Health> ();
		if (inventory == null)
			Debug.LogWarning("WARNING: GameObject missing Inventory");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject other_object = other.gameObject;

		if (other_object.tag == "rupee")
		{
			if (inventory != null)
				inventory.AddRupees(1);
			Destroy(other_object);

			//Play sound effect
			AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
		}
		if (other_object.tag == "heart")
		{
			if (inventory != null)
				health.AddHealth(1.0f);
			Destroy(other_object);

			AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
		}
		if (other_object.tag == "key") {
			if (inventory != null) {
				inventory.AddKey ();
				Debug.Log ("this ran:" + inventory.GetKeys().ToString());
			}
			Destroy (other_object);
		}
		if (other_object.tag == "bomb_pickup") {
			if (inventory != null) {
				inventory.AddBomb ();
			}
			Destroy (other_object);
		}
	}
}
