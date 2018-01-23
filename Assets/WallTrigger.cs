using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour {

	public GameObject hand;
	public bool vertical_wall;
	public bool left;
	public bool top;
	private bool canSpawnHand = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		if (canSpawnHand && other.tag == "Link")
			StartCoroutine(SpawnHand(other.gameObject));
	}

	IEnumerator SpawnHand(GameObject link)
	{
		string move1 = "left";
		string move2 = "right";
		Quaternion rotation = Quaternion.identity;
		canSpawnHand = false;
		float x = link.transform.position.x;
		float y = link.transform.position.y;

		if (vertical_wall) {
			if (left)
			{
				x -= 1;
				move1 = "right";
			}
			else
			{
				x += 1;
				move1 = "left";
			}
			y += 2;
			move2 = "down";
			if (y >= 41)
			{
				y -= 4;
				move2 = "up";
			}
		} else {
			if (top)
			{
				y += 1;
				move1 = "down";
			}
			else
			{
				y -= 1;
				move1 = "up";
			}
			x += 2;
			move2 = "left";
			if (x >= 76)
			{
				x -= 4;
				move2 = "right";
			}
		}



		Vector2 spawnPosition = new Vector2(x, y);
		GameObject newHand = (GameObject)Instantiate(hand, spawnPosition, Quaternion.identity);
		newHand.GetComponent<Wallmaster>().startMove(move1, move2);

		while (newHand != null)
		{
			yield return null;
		}

		//yield return new WaitForSeconds(10f);
		canSpawnHand = true;
	}
}
