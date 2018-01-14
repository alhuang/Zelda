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
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			cheat = true;
		}

		if (inventory == null) {
			gameOver.EndGame ();
		}

		if (cheat) {
			inventory.MaxInventory ();
			health.SetInvincible(true);
		}
	}
}
