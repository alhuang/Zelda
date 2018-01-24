using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOldMan : MonoBehaviour {
	public GameObject[] sprites;
	public GameObject text;
	public string toPrintText = "EASTMOST PENINSULA";
	public string toPrintTextBottom = "IS THE SECRET.";

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Link")
			Invoke ("StartAnimation", 1f);
	}

	private void StartAnimation() {
		foreach (GameObject sprite in sprites) {
			sprite.SetActive(true);
		}
		StartCoroutine (showWords ());
	}

	IEnumerator showWords() {
		text.GetComponent<TextMesh> ().text = "";
		foreach (char letter in toPrintText) {
			text.GetComponent<TextMesh> ().text += letter;
			yield return new WaitForSeconds (.2f);
		}

		text.GetComponent<TextMesh> ().text += "\n";
		foreach (char letter in toPrintTextBottom) {
			text.GetComponent<TextMesh> ().text += letter;
			yield return new WaitForSeconds (.2f);
		}

	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Link")
			Invoke ("StopAnimation", 1f);
	}

	private void StopAnimation() {
		foreach (GameObject sprite in sprites) {
			sprite.SetActive(false);
		}
		text.GetComponent<TextMesh> ().text = "";
	}
}
