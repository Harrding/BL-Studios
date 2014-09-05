using UnityEngine;
using System.Collections;

public class TestVillageScript : MonoBehaviour {

	public TestVillage village;
	private bool shouldConsume;

	// Use this for initialization
	void Start () {
		village = new TestVillage ();
		shouldConsume = true;
		StartCoroutine ("consumeResources");
	}
	
	// Update is called once per frame
	void Update () {
		int [] food = village.getFood();
		print ("bread = " + food[MasterClass.BREAD_ID]);
		print ("population = " + village.getPopulation());
		village.consumeResources ();
	}

	IEnumerator consumeResources() {
		while (shouldConsume) {
			village.consumeResources();
			yield return new WaitForSeconds(MasterClass.timeAmount);
		}
	}
}