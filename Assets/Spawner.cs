using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	private Enemy_Movement[] enemies;
	private Transform[] enemyPos;
	private SpriteRenderer[] enemySprites;
	private float[] speeds;
	private Vector2[] locations;
	private Sprite[] sprites;

	public Sprite bigCloud;
	public Sprite middleCloud;
	public Sprite littleCloud;

	void Start() {
		enemies = GetComponentsInChildren<Enemy_Movement> ();
		enemyPos = GetComponentsInChildren<Transform> ();
		enemySprites = GetComponentsInChildren<SpriteRenderer> ();
		speeds = new float[enemies.Length];
		locations = new Vector2[enemies.Length];
		sprites = new Sprite[enemies.Length];
		for (int i = 0; i < enemies.Length; i++) {
			speeds [i] = enemies [i].GetMovementSpeed();
			locations [i] = enemyPos [i].position;
			sprites [i] = enemySprites [i].sprite;
			enemies [i].movement_speed = 0f;
		}
	}

	//activate all enemies
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			for (int i = 0; i < enemies.Length; i++) {
				if (enemies [i] != null) {
					enemyPos [i].position = locations [i];
					StartCoroutine (SpawnEnemies(enemies[i], enemySprites[i],
										sprites[i], speeds[i]));
				}
			}
		}
	}

	IEnumerator SpawnEnemies(Enemy_Movement enemy, SpriteRenderer spriteRenderer,
								Sprite sprite, float speed) {
		spriteRenderer.sprite = null;
		yield return new WaitForSeconds (1.5f);
		spriteRenderer.sprite = bigCloud; 
		yield return new WaitForSeconds (.75f);
		spriteRenderer.sprite = middleCloud; 
		yield return new WaitForSeconds (.1f);
		spriteRenderer.sprite = littleCloud; 
		yield return new WaitForSeconds (.1f);
		spriteRenderer.sprite = sprite; 

		enemy.movement_speed = speed;
	}

	//activate all enemies
	void OnTriggerExit(Collider other) {
		if (other.tag == "Link") {
			for (int i = 0; i < enemies.Length; i++) {
				if (enemies [i] != null) {
					enemies [i].movement_speed = 0f;
				}
			}
		}
	}

}
