﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RupeeDisplayer : MonoBehaviour {

	public Inventory inventory;
	Text textComponent;

	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (inventory != null && textComponent != null)
		{
			textComponent.text = inventory.GetRupees().ToString();
		}
	}
}
