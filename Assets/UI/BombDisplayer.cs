using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombDisplayer : MonoBehaviour {

	Text textComponent;

	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text>();
	}
	
	public void UpdateBombs(int amount) {
		textComponent.text = amount.ToString ();
	}
}
