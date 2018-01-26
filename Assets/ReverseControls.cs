using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseControls : MonoBehaviour {
	ArrowKeyMovement AKM;

	void Start() {
		AKM = GetComponent<ArrowKeyMovement> ();
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			Debug.Log ("reversing");
			AKM.reverseEverything = !AKM.reverseEverything;
		}
	}
}
