using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

	public GameObject obj;
	public Vector2 spawnPosition;
	private bool objSpawned = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Health[] ts = GetComponentsInChildren<Health>();
		Debug.Log(ts.Length);
		if (ts.Length == 0 && !objSpawned)
		{
			//Debug.Log("Spawned key");
			Instantiate(obj, spawnPosition, Quaternion.identity);
			objSpawned = true;
		}
	}
}
