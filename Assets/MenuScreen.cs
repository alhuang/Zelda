using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Alpha1))
		{
			SceneManager.LoadScene("Alpha");
		}
		else if (Input.GetKey(KeyCode.Alpha2))
		{
			SceneManager.LoadScene("CustomLevel");
		}
	}
}
