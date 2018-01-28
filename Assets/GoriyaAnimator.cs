using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoriyaAnimator : MonoBehaviour {

	Animator animator;
	Enemy_Movement enemy_Movement;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		enemy_Movement = GetComponent<Enemy_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("horizontal", enemy_Movement.GetHorizontal());
		animator.SetFloat("vertical", enemy_Movement.GetVertical());
	}
}
