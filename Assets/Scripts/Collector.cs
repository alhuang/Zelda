using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

	public AudioClip rupee_collection_sound_clip;
	Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GetComponent<Inventory>();
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
	}
}
