using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject obstacle;
	public float dist;
	public float width;

	private bool shouldCreate;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		shouldCreate = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(shouldCreate) {
			shouldCreate = false;
			StartCoroutine("createObstacle");
		}

	}

	IEnumerator createObstacle() {
		yield return new WaitForSeconds(1f);
		GameObject clone = (GameObject)Instantiate (obstacle, player.transform.position + new Vector3(Random.Range (-1f * width, width), dist, 0), player.transform.rotation);
		shouldCreate = true;
	}
}
