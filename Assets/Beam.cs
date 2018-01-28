using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

	Rigidbody rb;
	//public Sprite newSprite;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		StartCoroutine(speedUp());
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

		if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Link")
		{
			//StartCoroutine(other.gameObject.GetComponent<Health>().PushBackDir((this.transform.position - other.gameObject.transform.position).normalized));
			Invoke("destroySelf", .1f);
		}
	}

	void destroySelf() {
		Destroy (gameObject);
	}

	IEnumerator speedUp()
	{
		yield return new WaitForSeconds(.5f);
		rb.velocity = rb.velocity * 8;
	}

}
