using UnityEngine;
using System.Collections;

public class Accelerometer2D : MonoBehaviour {
	public float speed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -Screen.width / 290) {
			transform.position = new Vector3 (-Screen.width / 290, transform.position.y, transform.position.z);
		}
		if (transform.position.x > Screen.width / 290) {
			transform.position = new Vector3 (Screen.width / 290, transform.position.y, transform.position.z);
		}
	}
	
	void FixedUpdate () {
		transform.Translate(Input.acceleration.x * Time.fixedDeltaTime * speed, 0, 0);
	}
}
