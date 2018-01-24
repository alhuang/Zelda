using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour {
	public GameObject GameOverScreen;
	public Camera camera;
	public AudioClip EndGameSound;


	private CheatCode cheatC;
	private bool gameOver = false;

	// Use this for initialization
	void Start () {
		cheatC = GetComponent<CheatCode> ();
	}
	
	public void EndGame() {
		/*
		if (cheatC.cheat) {
			return;
		}
		*/
		gameOver = true;
		GameOverScreen.SetActive (true);
		camera.GetComponent<AudioSource> ().clip = EndGameSound;
		camera.GetComponent<AudioSource> ().Play ();
	}

	void Update() {
		if (gameOver) {
			if(Input.GetKeyDown(KeyCode.Space)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}
}
