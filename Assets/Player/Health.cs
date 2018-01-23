using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	float health_count = 3f;
	public float pushBackAmount = 100f;
	public float damageTime = 1f;
	public float damageFlashFreq = 5f;
	public float max_health;
	public bool invincible = false;
	public HealthDisplayer healthUI;

	private SpriteRenderer spriteRenderer;
	private Rigidbody rb;
	private DropItem dropItem;

	void Start()
	{
		health_count = max_health;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody> ();
		dropItem = GetComponent<DropItem> ();
	}

	public void SubtractHealth(float num_health) {
		if (!invincible)
		{
			health_count = Mathf.Max(0f, health_count - num_health);
			StartCoroutine(ShowDamage());
			if (this.tag == "Link") {
				healthUI.updateHealth (health_count);
			}
		}
	}

	private IEnumerator ShowDamage() {
		invincible = true;

		ArrowKeyMovement AKM = GetComponent<ArrowKeyMovement> ();
		if (AKM != null) {
			AKM.SetCanMove (false);
		}

		for (int i = 0; i < damageFlashFreq; ++i) {
			spriteRenderer.color = Color.red;
			yield return new WaitForSeconds (damageTime / damageFlashFreq);
			spriteRenderer.color = Color.white;
			yield return new WaitForSeconds (damageTime / damageFlashFreq);
		}

		invincible = false;
		if (AKM != null) {
			AKM.SetCanMove (true);
		}
	}

	public void AddHealth(float num_health) {
		health_count = Mathf.Min (max_health, health_count + num_health);
		if (this.tag == "Link") {
			healthUI.updateHealth (health_count);
		}
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

	void Update()
	{
		if (health_count == 0)
		{
			if (dropItem != null) {
				dropItem.dropRupee ();
				dropItem.dropKey ();
				dropItem.dropHeart ();
			}
			Destroy(gameObject);
		}
	}

	public IEnumerator PushBackDir(Vector3 direction) {
		for (int i = 0; i < 100; i++) {
			if (rb == null) {
				break;
			}
			rb.AddForce (direction * pushBackAmount);
			yield return new WaitForSeconds (.01f);
		}
	}

	public void callPushBackDir(Vector3 direction) {
		StartCoroutine (PushBackDir (direction));
	}
}
