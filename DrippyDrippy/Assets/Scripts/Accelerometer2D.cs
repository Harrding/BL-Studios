using UnityEngine;
using System.Collections;

public class Accelerometer2D : MonoBehaviour {
	public float speed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		transform.Translate(Input.acceleration.x * Time.fixedDeltaTime * speed, 0, 0);
	}
}
