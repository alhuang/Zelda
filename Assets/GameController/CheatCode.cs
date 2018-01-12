using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour {

	public Inventory inventory;

	private bool cheat = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			cheat = true;
		}

		if (cheat) {
			inventory.MaxInventory ();
		}
	}
}
