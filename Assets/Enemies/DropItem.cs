using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

	public float RupeeChance = .25f;
	public float KeyChance = 0f;
	public float HeartChance = .1f;
	public float BombChance = 0f;

	public GameObject Rupee;
	public GameObject Key;
	public GameObject Heart;
	public GameObject Bomb;

	public void dropRupee() {
		float value = Random.value;

		if (value < RupeeChance) {
			GameObject rupeeObj = Instantiate (Rupee);
			rupeeObj.transform.position = this.transform.position;
			Destroy(rupeeObj, 10f);
		}
	}

	public void dropKey() {
		float value = Random.value;

		if (value < KeyChance) {
			GameObject keyObj = Instantiate (Key);
			keyObj.transform.position = this.transform.position;
		}
	}

	public void dropHeart() {
		float value = Random.value;

		if (value < HeartChance) {
			GameObject heartObj = Instantiate (Heart);
			heartObj.transform.position = this.transform.position;
			Destroy(heartObj, 10f);
		}
	}

	public void dropBomb() {
		float value = Random.value;

		if (value < BombChance) {
			GameObject BombObj = Instantiate (Bomb);
			BombObj.transform.position = this.transform.position;
			Destroy(BombObj, 10f);
		}
	}
}
