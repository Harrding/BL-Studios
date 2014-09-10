﻿using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject player;
	public GameObject obstacle, powerup;
	public float dist;
	public float width;
	public float threshold, gap, thresholdPU, gapPU;
	
	private bool shouldCreate;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		shouldCreate = true;
		width = Screen.width / 290;
	}
	
	void Update () {
		if (transform.position.y < threshold) {
			GameObject clone = (GameObject)Instantiate (obstacle, transform.position + new Vector3(Random.Range (-1f * width, width), dist, -transform.position.z), transform.rotation);
			threshold -= gap;
		}
		spawnPowerup ();
		
	}

	void spawnPowerup () {
		if(transform.position.y < thresholdPU) {
			if (Random.Range (0f, 1f) < 0.2f) {
				GameObject clone = (GameObject)Instantiate (powerup, transform.position + new Vector3(Random.Range (-1f * width, width), dist, -transform.position.z - 1), transform.rotation);
			}
			thresholdPU -= gapPU;
		}

	}

	// Update is called once per frame
	/*void FixedUpdate () {

		if(shouldCreate) {
			shouldCreate = false;
			StartCoroutine("createObstacle");
		}

	}

	IEnumerator createObstacle() {
		yield return new WaitForSeconds(1f);
		GameObject clone = (GameObject)Instantiate (obstacle, player.transform.position + new Vector3(Random.Range (-1f * width, width), dist, 0), player.transform.rotation);
		shouldCreate = true;
	}*/
}
