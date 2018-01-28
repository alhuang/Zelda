using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPositionToAquamentus : MonoBehaviour {

	public GameObject aqua;
	AquamentusMovement aquamentus;

	void Start()
	{
		aquamentus = aqua.GetComponentInParent<AquamentusMovement>();
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Link")
		{
			aquamentus.SetLinksPosition(gameObject.name);
			

		}

	}
}
