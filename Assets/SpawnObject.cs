using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

	public GameObject obj;
	public Vector2 spawnPosition;
	public AudioClip discovery;
	private bool objSpawned = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Health[] ts = GetComponentsInChildren<Health>();
		if (ts.Length == 0 && !objSpawned)
		{
			Instantiate(obj, spawnPosition, Quaternion.identity);
			objSpawned = true;
			AudioSource.PlayClipAtPoint(discovery, Camera.main.transform.position);
		}
	}
}
