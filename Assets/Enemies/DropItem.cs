using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

	public float RupeeChance = .25f;
	public float KeyChance = 0f;

	public GameObject Rupee;
	public GameObject Key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void dropRupee() {
		float value = Random.value;
		Debug.Log ("Random value for rupee drop: " + value.ToString ());

		if (value < RupeeChance) {
			GameObject rupeeObj = Instantiate (Rupee);
			rupeeObj.transform.position = this.transform.position;
		}
	}

	public void dropKey() {
		float value = Random.value;
		Debug.Log ("Random value for key drop: " + value.ToString ());

		if (value < KeyChance) {
			GameObject keyObj = Instantiate (Key);
			keyObj.transform.position = this.transform.position;
		}
	}
}
