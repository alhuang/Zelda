using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public int rupee_count = 0;
	public int key_count = 0;
	public int bomb_count = 0;

	public RupeeDisplayer rupeeDisplayer;
	public KeyDisplayer keyDisplayer;
	public BombDisplayer bombDisplayer;
	Attack attack;

	void Start()
	{
		attack = GetComponent<Attack>();
	}

	public void AddRupees(int num_rupees)
	{
		rupee_count += num_rupees;
		rupeeDisplayer.UpdateRupees (rupee_count);
	}

	public int GetRupees()
	{
		return rupee_count;
	}

	//Pretty sure that you only ever increment keys by one
	public void AddKey() {
		key_count += 1;
		keyDisplayer.UpdateKeys (key_count);
	}

	public void RemoveKey() {
		key_count -= 1;
		keyDisplayer.UpdateKeys (key_count);
	}

	public int GetKeys() {
		return key_count;
	}

	public void AddBomb() {
		bomb_count += 1;
		bombDisplayer.UpdateBombs (bomb_count);
	}

	public void RemoveBomb() {
		bomb_count -= 1;
		bombDisplayer.UpdateBombs (bomb_count);
	}

	public int GetBombs() {
		return bomb_count;
	}

	public void MaxInventory() {
		bomb_count = 99;
		key_count = 99;
		rupee_count = 999;
		bombDisplayer.UpdateBombs (key_count);
		keyDisplayer.UpdateKeys (key_count);
		rupeeDisplayer.UpdateRupees (rupee_count);
		attack.hasBoomerang = true;
		attack.hasBow = true;
	}
}
