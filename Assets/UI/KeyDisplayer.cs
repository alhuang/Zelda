﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDisplayer : MonoBehaviour {
	Text textComponent;

	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text>();
	}
	
	public void UpdateKeys(int amount) {
		textComponent.text = amount.ToString ();
	}
}
