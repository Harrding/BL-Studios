using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public const KeyCode LEFT = KeyCode.A;
	public const KeyCode RIGHT = KeyCode.D;
	public const float scaleValue = 100;
	public float speed;
	public float waterAmount;
	public bool gameOver;

	//
	// Use this for initialization
	void Start () {
		waterAmount = scaleValue;
		gameOver = false;
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

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.CompareTag("NormalObs")){
			changeWaterAmount( collider.gameObject.GetComponent<WaterChanger>().changeWaterValue());
		}
	}

	void changeWaterAmount(float waterValue) {
		waterAmount += waterValue;
		transform.localScale = new Vector3 (waterAmount / scaleValue , waterAmount / scaleValue, transform.localScale.z);
		if (waterAmount <= 0) {
			gameOver = true;
		}
	}


}
