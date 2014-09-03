using UnityEngine;
using System.Collections;

public class SpawnNewBackground : MonoBehaviour {
	public GameObject background, cameraobj;
	public bool spawned;
	public int spawnlocation = -32;

	// Use this for initialization
	void Start () {
		spawned = false;
		cameraobj = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraobj.transform.position.y < transform.position.y && spawned == false) {
			spawned = true;
			GameObject newback = Instantiate (background, new Vector3(0,spawnlocation,transform.position.z),transform.rotation) as GameObject;
			newback.GetComponent<SpawnNewBackground>().spawnlocation = spawnlocation - 16;
		}
	}
}
