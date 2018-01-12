using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	int rupee_count = 0;
	float health_count = 3f;

	private float max_health = 3f;

	public void AddRupees(int num_rupees)
	{
		rupee_count += num_rupees;
	}

	public int GetRupees()
	{
		return rupee_count;
	}

	public void SubtractHealth(float num_health) {
		health_count = Mathf.Max (0f, health_count - num_health);
	}

	public void AddHealth(float num_health) {
		health_count = Mathf.Min (max_health, health_count + num_health);
	}

	public float GetHealth() {
		return health_count;
	}

	public void AddMaxHealth(float num_health) {
		max_health += num_health;
	}
	
}
