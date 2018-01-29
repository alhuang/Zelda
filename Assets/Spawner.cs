using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	private Transform[] enemyPos;
	private SpriteRenderer[] enemySprites;
	private Animator[] animators;
	private Vector2[] locations;
	private Sprite[] sprites;
	private bool setLocBool;

	public Sprite bigCloud;
	public Sprite middleCloud;
	public Sprite littleCloud;

	void Start() {
		Transform[] enemyPos2 = GetComponentsInChildren<Transform> ();
		enemyPos = new Transform[enemyPos2.Length - 1];
		int j = 0;
		foreach (Transform trans in enemyPos2) {
			if (trans != GetComponent<Transform>()) {
				enemyPos [j] = trans;
				j++;
			}
		}
		enemySprites = GetComponentsInChildren<SpriteRenderer> ();
		locations = new Vector2[enemyPos.Length];
		sprites = new Sprite[enemyPos.Length];
		for (int i = 0; i < enemyPos.Length; i++) {
			locations [i] = enemyPos [i].position;
			Debug.Log (enemyPos.Length);
			sprites [i] = enemySprites [i].sprite;
		}

		animators = GetComponentsInChildren<Animator> ();

		foreach (Transform enemy in enemyPos)
		{
			enemy.gameObject.SetActive(false);
		}

	}

	//activate all enemies
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link") {
			for (int i = 0; i < enemyPos.Length; i++) {
				if (enemyPos [i] != null) {
					enemyPos[i].gameObject.SetActive(true);
					//enemyPos [i].position = locations [i];
					Animator anim = null;
					if (animators.Length > i) {
						anim = animators [i];
					}
					StartCoroutine (SpawnEnemies(enemySprites[i], sprites[i], anim));
					StartCoroutine (SetLocations(enemyPos[i], locations[i]));
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Link")
		{
			foreach (Transform enemy in enemyPos)
			{
				if (enemy != null)
				{
					enemy.gameObject.SetActive(false);
				}
			}
		}

	}

	//spaghetti code
	IEnumerator SetLocations(Transform trans, Vector3 Loc) {
		setLocBool = true;
		if (trans != null) {
			while (setLocBool) {
				trans.position = Loc;
				yield return null;
			}
		}
	}

	IEnumerator SpawnEnemies(SpriteRenderer spriteRenderer,
		Sprite sprite, Animator anim) {
		if (anim != null) {
			anim.enabled = false;
		}

		spriteRenderer.sprite = null;
		yield return new WaitForSeconds (1.5f);
		spriteRenderer.sprite = bigCloud; 
		yield return new WaitForSeconds (.8f);
		spriteRenderer.sprite = middleCloud; 
		yield return new WaitForSeconds (.1f);
		spriteRenderer.sprite = littleCloud; 
		yield return new WaitForSeconds (.1f);
		spriteRenderer.sprite = sprite;


		if (anim != null) {
			anim.enabled = true;
		}

		setLocBool = false;
	}


}
