using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public const KeyCode LEFT = KeyCode.A;
	public const KeyCode RIGHT = KeyCode.D;
	public const float scaleValue = 100;
	public float speed;
	public float waterAmount;
	public GameObject splashPS;

	// Use this for initialization
	void Start () {
		waterAmount = scaleValue;
	}
	
	// Update is called once per frame
	void Update () {
		if(rigidbody2D.velocity.y < -10){
			rigidbody2D.velocity = new Vector2 (0, -10);
			rigidbody2D.gravityScale = 0;
		}
		if(Input.GetKey(LEFT)) {
			transform.Translate(speed * Time.fixedDeltaTime * -1, 0, 0);
		}
		if(Input.GetKey (RIGHT)) {
			transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
		}
		//transform.Translate (0, -speed * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.CompareTag("NormalObs")){
			changeWaterAmount( collider.gameObject.GetComponent<WaterChanger>().changeWaterValue());
			if(collider.gameObject.GetComponent<WaterChanger>().changeWaterValue() < 0) {
				Instantiate(splashPS, new Vector3(transform.position.x, transform.position.y, -5), transform.rotation);
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y * .6f);
			}
			Destroy (collider.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D collider) {
		if(collider.gameObject.CompareTag("NormalObs")){
			changeWaterAmount( collider.gameObject.GetComponent<WaterChanger>().changeWaterValue());

		}
	}

	void changeWaterAmount(float waterValue) {
		waterAmount += waterValue;
		transform.localScale = new Vector3 (waterAmount / scaleValue , waterAmount / scaleValue, transform.localScale.z);
		if (waterAmount <= 0) {
			Application.LoadLevel("HighScoreScene");
		}
	}


}
