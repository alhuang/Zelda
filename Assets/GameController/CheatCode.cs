using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour {

	public Inventory inventory;
	public Health health;

	public bool cheat = false;
	private GameOver gameOver;

	void Start() {
		gameOver = GetComponent<GameOver> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			cheat = true;
			health.AddMaxHealth (100);
		}

		if (inventory == null) {
			gameOver.EndGame ();
		}

		if (cheat) {
			inventory.MaxInventory ();
			health.AddHealth (100);
		}
	}
}
