using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

	public GameObject obj;
	private bool objSpawned = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform[] ts = GetComponentsInChildren<Transform>();
		if (ts.Length == 0 && !objSpawned)
		{
			Debug.Log("Spawned key");
			Instantiate(obj, this.transform.position, Quaternion.identity);
			objSpawned = true;
		}
	}
}
