using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour {

	Animator animator;
	ArrowKeyMovement arrowKeyMovement;
	bool noAnimations = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		arrowKeyMovement = GetComponent<ArrowKeyMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!noAnimations) {
			animator.SetFloat ("horizontal_input", Input.GetAxisRaw ("Horizontal"));
			animator.SetFloat ("vertical_input", Input.GetAxisRaw ("Vertical"));
			if (Input.GetKeyDown (KeyCode.X))
				StartCoroutine (AttackAnimation ());

			if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
			{
				animator.speed = 0.0f;
			}
			else
			{
				animator.speed = 1.0f;
			}
		}

		
	}

	IEnumerator AttackAnimation()
	{
		animator.SetBool("attack", true);
		yield return new WaitForSeconds(.25f);
		animator.SetBool("attack", false);
	}

	public IEnumerator StopAnimations(float time) {
		noAnimations = true;
		yield return new WaitForSeconds (time);
		noAnimations = false;
	}
}
