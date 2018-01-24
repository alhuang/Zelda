using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallmaster : MonoBehaviour {

	//Rigidbody rb;
	//public GameObject camera;
	public GameObject topMapUI;
	Transform camera;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
		camera = Camera.main.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Link")
		{
			this.transform.position = other.gameObject.transform.position;
			this.GetComponent<SpriteRenderer>().sortingOrder = 3;
			other.gameObject.GetComponent<ArrowKeyMovement>().ignoreControls = true;
			other.gameObject.GetComponent<Collider>().enabled = false;
			StartCoroutine(GrabbedLink(other.gameObject));
			
		}
	}

	public void startMove(string move1, string move2)
	{
		StartCoroutine(Move(move1, move2));
	}

	public IEnumerator Move(string move1, string move2)
	{
		Debug.Log("Move" + move1 + " " + move2);
		Rigidbody rb = this.GetComponent<Rigidbody>();
		//rb2.velocity = new Vector2(1, 1);
		if (move1 == "right")
		{
			rb.velocity = new Vector2(1, 0);
		}
		else if (move1 == "left")
		{
			rb.velocity = new Vector2(-1, 0);
		}
		else if (move1 == "up")
		{
			rb.velocity = new Vector2(0, 1);
		}
		else if (move1 == "down")
		{
			rb.velocity = new Vector2(0, -1);
		}

		yield return new WaitForSeconds(1f);

		if (move2 == "right")
		{
			rb.velocity = new Vector2(1, 0);
		}
		else if (move2 == "left")
		{
			rb.velocity = new Vector2(-1, 0);
		}
		else if (move2 == "up")
		{
			rb.velocity = new Vector2(0, 1);
		}
		else if (move2 == "down")
		{
			rb.velocity = new Vector2(0, -1);
		}

		yield return new WaitForSeconds(2f);

		if (move1 == "right")
		{
			rb.velocity = new Vector2(-1, 0);
		}
		else if (move1 == "left")
		{
			rb.velocity = new Vector2(1, 0);
		}
		else if (move1 == "up")
		{
			rb.velocity = new Vector2(0, -1);
		}
		else if (move1 == "down")
		{
			rb.velocity = new Vector2(0, 1);
		}

		yield return new WaitForSeconds(1f);

		rb.velocity = Vector3.zero;
		yield return new WaitForSeconds(.15f);
		Destroy(gameObject);
	}

	IEnumerator GrabbedLink(GameObject other)
	{
		while (this.GetComponent<Rigidbody>().velocity != Vector3.zero)
		{
			other.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity;
			yield return null;
		}
		other.GetComponent<Rigidbody>().velocity = Vector3.zero;
		camera.position = new Vector3(39.5f, 7f, -10f);
		other.transform.position = new Vector3(39.5f, 1.5f);
		other.GetComponent<Collider>().enabled = true;
		other.gameObject.GetComponent<ArrowKeyMovement>().ignoreControls = false;
		topMapUI.transform.position = new Vector2(-262f, -66f);
		Destroy(gameObject);
	}
}
