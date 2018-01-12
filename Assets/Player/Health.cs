using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	float health_count = 3f;
	public float max_health;
	public GameOver gameOver;

	public void SubtractHealth(float num_health) {
		health_count = Mathf.Max (0f, health_count - num_health);

		if (health_count < .1f) {
			gameOver.EndGame ();
		}
	}

	public void AddHealth(float num_health) {
		health_count = Mathf.Min (max_health, health_count + num_health);
	}

	public float GetHealth() {
		return health_count;
	}

	public float GetMaxHealth()
	{
		return max_health;
	}

	public void AddMaxHealth(float num_health) {
		max_health += num_health;
	}

	void Start()
	{
		health_count = max_health;
	}

	void Update()
	{
		if (health_count == 0)
		{
			Destroy(gameObject);
		}
	}

}
