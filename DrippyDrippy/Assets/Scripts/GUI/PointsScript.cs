using UnityEngine;
using System.Collections;

public class PointsScript : MonoBehaviour {
	public int points;
	public float multiplier;

	// Use this for initialization
	void Start () {
		points = 0;
		multiplier = 200;
	}
	
	// Update is called once per frame
	void Update () {
		points += (int)(Time.deltaTime * multiplier);
	}

	void OnGUI() {
		GUI.Label (new Rect (0, 0, 100f, 100f), "" + points);
	}
}
