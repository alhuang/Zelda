using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	ArrowKeyMovement arrowKeyMovement;
	Collider col;
	string direction_facing = "South";

	// Use this for initialization
	void Start () {
		arrowKeyMovement = gameObject.GetComponentInParent<ArrowKeyMovement>();
		col = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		direction_facing = arrowKeyMovement.GetDirection();
		if (Input.GetKeyDown(KeyCode.X))
		{
			StartCoroutine("AttackBox");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "enemy")
			Debug.Log("lower enemy hp");
	}

	IEnumerator AttackBox()
	{
		col.enabled = true;
		if (direction_facing == "South")
		{
			this.transform.localPosition = new Vector3(0f, -.75f);
		}
		else if (direction_facing == "North")
		{
			this.transform.localPosition = new Vector3(0f, .75f);
		}
		else if (direction_facing == "East")
		{
			this.transform.localPosition = new Vector3(.75f, -0f);
		}
		else if (direction_facing == "West")
		{
			this.transform.localPosition = new Vector3(-.75f, 0f);
		}
		yield return new WaitForSeconds(.5f);
		col.enabled = false;
	}
}
