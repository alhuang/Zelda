using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Alive");
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("onTriggerEnter");
		if (other.gameObject.tag == "enemy")
			Debug.Log("lower enemy hp");
	}

}
