using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBladesMovement : MonoBehaviour {
	public Vector3 rayCastOne;
	public Vector3 rayCastTwo;
	public float movement_speed = 1f;
	public float speedIncrease = 1.1f;

	private bool returning = false;
	private bool speedUp = true;
	private Vector3 startingLocation;
	private Rigidbody rb;

	void Start() {
		startingLocation = transform.position;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawRay (transform.position, rayCastOne, Color.green);
		//Debug.DrawRay (transform.position, rayCastTwo, Color.red);
		RaycastHit other;
		RaycastHit other2;

		if (!returning) {
			//if hit raycast, change movement speed along raycase
			if (Physics.Raycast (transform.position, rayCastOne.normalized, out other, rayCastOne.magnitude)) {
				if (other.collider.tag == "Link") {
					returning = true;
					rb.velocity = rayCastOne.normalized * movement_speed;
					StartCoroutine (speedUpBlades ());
				}
			}
			if (Physics.Raycast (transform.position, rayCastTwo.normalized, out other2, rayCastTwo.magnitude)) {
				Debug.Log ("raycast 2");
				if (other2.collider.tag == "Link") {
					returning = true;
					rb.velocity = rayCastTwo.normalized * movement_speed;
					StartCoroutine (speedUpBlades ());
				}
			}
		}
	}

	public void OnTriggerEnter(Collider other) {
		speedUp = false;
		StartCoroutine (ReturnToHome ());
	}

	IEnumerator speedUpBlades() {
		speedUp = true;
		while (speedUp) {
			rb.velocity *= speedIncrease;
			yield return new WaitForSeconds (.1f);
		}
	}

	IEnumerator ReturnToHome() {
		while ((transform.position - startingLocation).magnitude > .1f) {
			rb.velocity = (startingLocation - transform.position).normalized * movement_speed;
			yield return null;
		}
		rb.velocity = Vector3.zero;
		returning = false;
	}
}
