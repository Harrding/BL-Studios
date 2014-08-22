using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public const KeyCode LEFT = KeyCode.A;
	public const KeyCode RIGHT = KeyCode.D;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(LEFT)) {
			transform.Translate(speed * Time.fixedDeltaTime * -1, 0, 0);
		}
		if(Input.GetKey (RIGHT)) {
			transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
		}
	}
}
