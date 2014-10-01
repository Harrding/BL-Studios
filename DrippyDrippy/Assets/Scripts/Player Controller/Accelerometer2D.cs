using UnityEngine;
using System.Collections;

public class Accelerometer2D : MonoBehaviour {
	public float speed;
	float frame = (float)(((float)Screen.width / (float)Screen.height) * 6.0);
	//(Screen.width + Screen.height) / 350;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -frame) {
			transform.position = new Vector3 (-frame, transform.position.y, transform.position.z);
		}
		if (transform.position.x > frame) {
			transform.position = new Vector3 (frame, transform.position.y, transform.position.z);
		}
	}
	
	void FixedUpdate () {
		transform.Translate(Input.acceleration.x * Time.fixedDeltaTime * speed, 0, 0);
	}
}
