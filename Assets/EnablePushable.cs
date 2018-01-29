using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePushable : MonoBehaviour {
	public GameObject obj = null;
	private bool objEnabled = false;
	// Use this for initialization

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Link")
		{
			Health[] ts = GetComponentsInChildren<Health>();
			if (ts.Length == 0 && !objEnabled) {
				obj.GetComponent<PushableTile> ().pushed = false;
				objEnabled = true;
			} else if(!objEnabled){
				obj.GetComponent<PushableTile> ().pushed = true;
			}
		}

	}
}
