using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject other_object = other.gameObject;

		if (other_object.tag == "rupee")
		{
			Debug.Log("Rupee collected!");
			Destroy(other_object);
		}
	}
}
