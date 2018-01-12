using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	int rupee_count = 0;
	int key_count = 0;
	int bomb_count = 0;

	public void AddRupees(int num_rupees)
	{
		rupee_count += num_rupees;
	}

	public int GetRupees()
	{
		return rupee_count;
	}

	//Pretty sure that you only increment keys by one
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
}
