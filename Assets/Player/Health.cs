using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	float health_count = 3f;
	public float max_health;
	public bool invincible = false;

	private SpriteRenderer spriteRenderer;

	public void SubtractHealth(float num_health) {
		health_count = Mathf.Max (0f, health_count - num_health);
		StartCoroutine (ShowDamage());
	}

	private IEnumerator ShowDamage() {
		spriteRenderer.color = Color.red;
		invincible = true;

		ArrowKeyMovement AKM = GetComponent<ArrowKeyMovement> ();
		if (AKM != null) {
			AKM.SetCanMove (false);
		}

		yield return new WaitForSeconds (1f);
		spriteRenderer.color = Color.white;
		invincible = false;
		if (AKM != null) {
			AKM.SetCanMove (true);
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

	public void SetInvincible(bool toggle) {
		invincible = toggle;
	}

	void Start()
	{
		health_count = max_health;
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		if (health_count == 0)
		{
			Destroy(gameObject);
		}
	}

}
