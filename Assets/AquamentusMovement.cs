using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquamentusMovement : MonoBehaviour {

	public float attackspeed = 5f;
	public float speed = 0.5f;
	public float beam_speed = .5f;
	public GameObject beam;
	public AudioClip RoarBeamsSound;

	Rigidbody rb;
	bool move = true;
	bool attacking = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (move)
		{
			StartCoroutine(Move());
		}
		if (!attacking)
		{
			StartCoroutine(Attack());
		}

	}

	IEnumerator Move()
	{
		move = false;
		rb.velocity = new Vector2(Random.Range(-1, 2), 0) * speed;
		yield return new WaitForSeconds(0.5f);
		move = true;
	}

	IEnumerator Attack()
	{
		attacking = true;
		//AudioSource.PlayClipAtPoint(RoarBeamsSound, Camera.main.transform.position);
		GameObject beam1 = (GameObject)Instantiate(beam, new Vector3(this.transform.position.x, this.transform.position.y + .25f), Quaternion.identity);
		GameObject beam2 = (GameObject)Instantiate(beam, new Vector3(this.transform.position.x, this.transform.position.y + .25f), Quaternion.identity);
		GameObject beam3 = (GameObject)Instantiate(beam, new Vector3(this.transform.position.x, this.transform.position.y + .25f), Quaternion.identity);

		beam1.GetComponent<Rigidbody>().velocity = new Vector2(-1f, .33f) * beam_speed;
		beam2.GetComponent<Rigidbody>().velocity = new Vector2(-1f, 0f) * beam_speed;
		beam3.GetComponent<Rigidbody>().velocity = new Vector2(-1f, -.33f) * beam_speed;

		yield return new WaitForSeconds(attackspeed);
		attacking = false;
	}
}
