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

	public void AddRupees(int num_rupees)
	{
		rupee_count += num_rupees;
	}

	public int GetRupees()
	{
		return rupee_count;
	}

	//Pretty sure that you only ever increment keys by one
	public void AddKey() {
		key_count += 1;
	}

	public void RemoveKey() {
		key_count -= 1;
	}

	public int GetKeys() {
		return key_count;
	}

	public void AddBomb() {
		bomb_count += 1;
	}

	public void RemoveBomb() {
		bomb_count -= 1;
	}

	public int GetBombs() {
		return bomb_count;
	}

	public void MaxInventory() {
		bomb_count = 99;
		key_count = 99;
		rupee_count = 9999;
	}
}
