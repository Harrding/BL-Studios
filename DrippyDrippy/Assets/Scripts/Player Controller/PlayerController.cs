using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public const KeyCode LEFT = KeyCode.A;
	public const KeyCode RIGHT = KeyCode.D;
	public const float scaleValue = 100;
	public float speed;
	public float waterAmount;
	public int logcount, PUcount;
	public bool dead = false;
	public GameObject splashPS, logPS, pointcounter, musicobj, logsplash, powersplash;

	float tempscale;
	public float maxVelocity;
	// Use this for initialization
	void Start () {
		waterAmount = scaleValue;
		pointcounter = GameObject.FindGameObjectWithTag ("Points");
		musicobj = GameObject.FindGameObjectWithTag ("Music");
		logsplash = GameObject.FindGameObjectWithTag ("LogSplash");
		powersplash = GameObject.FindGameObjectWithTag ("PowerSplash");
		logcount = 0;
		PUcount = 0;
		maxVelocity = -8/5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(rigidbody2D.velocity.y < maxVelocity){
			rigidbody2D.velocity = new Vector2 (0, maxVelocity);
			tempscale = rigidbody2D.gravityScale;
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
		if(collider.gameObject.CompareTag("NormalObs") && dead == false){
			if (collider.gameObject.GetComponent<WaterChanger>().changeWaterValue() > 0) {
				powersplash.gameObject.GetComponent<AudioSource>().Play();
				PUcount++;
			}
			else {
				Instantiate (logPS, new Vector3(collider.transform.position.x, collider.transform.position.y, -6), Quaternion.Euler(new Vector3(-90, 0, 0)));
				logsplash.gameObject.GetComponent<AudioSource>().Play();
				logcount++;
			}
			changeWaterAmount( collider.gameObject.GetComponent<WaterChanger>().changeWaterValue());
			if(collider.gameObject.GetComponent<WaterChanger>().changeWaterValue() < 0) {
				Instantiate(splashPS, new Vector3(transform.position.x, transform.position.y, -5), transform.rotation);
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y * .2f);
				rigidbody2D.gravityScale = tempscale;
			}
			Destroy (collider.gameObject);

		}
	}
	void incrementLevel() {
		rigidbody2D.gravityScale = tempscale + .01f;
		tempscale = rigidbody2D.gravityScale;
		maxVelocity -= 8f/5f;
	}
	void OnCollisionEnter2D(Collision2D collider) {
		if(collider.gameObject.CompareTag("NormalObs") && dead == false){
			changeWaterAmount( collider.gameObject.GetComponent<WaterChanger>().changeWaterValue());
		}
	}

	void changeWaterAmount(float waterValue) {
		waterAmount += waterValue;
		transform.localScale = new Vector3 (waterAmount / scaleValue , waterAmount / scaleValue, transform.localScale.z);
		if (waterAmount <= 20) {
			if (MasterClass.getHighestScore() < pointcounter.gameObject.GetComponent<PointsScript>().points) {
				MasterClass.saveHighestScore(pointcounter.gameObject.GetComponent<PointsScript>().points);
				MasterClass.newhighscore = true;
			}
			if (MasterClass.getObstaclesHit () < logcount)
				MasterClass.saveObstaclesHit(logcount);
			if (MasterClass.getPUCollected () < PUcount)
				MasterClass.savePUCollected(PUcount);
			MasterClass.musicon = false;
			Destroy (musicobj);
			pointcounter.gameObject.GetComponent<PointsScript>().activateDeath (logcount, PUcount);
			waterAmount = 0;
			dead = true;
		}
	}


}
