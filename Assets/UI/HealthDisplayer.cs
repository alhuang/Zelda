using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : MonoBehaviour {

	public GameObject[] hearts;
	public Sprite emptyHeart;
	public Sprite halfHeart;
	public Sprite fullHeart;
	public GameOver gameOver;


	// Use this for initialization
	void Start () {
		updateHealth (3f);
	}

	public void updateHealth(float curHealth) {
		//fill up all hearts before curHealth
		for (int i = 0; i < curHealth; ++i) {
			hearts [i].GetComponent<Image> ().sprite = fullHeart;
		}

		//check if there's half a heart to insert
		//then fill up rest of hearts
		float halfLocation = (float) Mathf.Floor (curHealth);
		if (curHealth - halfLocation > .1f) {
			hearts [(int)halfLocation].GetComponent<Image> ().sprite = halfHeart;
			for (int i = (int)halfLocation + 1; i < hearts.Length; i++) {
				hearts [i].GetComponent<Image> ().sprite = emptyHeart;
			}
		} else {
			for (int i = (int)halfLocation; i < hearts.Length; i++) {
				hearts [i].GetComponent<Image> ().sprite = emptyHeart;
			}
		}


		if (curHealth < .4f) {
			gameOver.EndGame ();
		}
	}
}
