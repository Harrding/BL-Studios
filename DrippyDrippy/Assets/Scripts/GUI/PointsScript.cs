using UnityEngine;
using System.Collections;

public class PointsScript : MonoBehaviour {
	public int points;
	public float multiplier, time;
	//
	// Use this for initialization
	void Start () {
		time = 0.1f;
		points = 0;
		multiplier = 200;
		Time.timeScale = time;
		Invoke ("timeChange",time);
	}
	
	// Update is called once per frame
	void Update () {
		points += (int)(Time.deltaTime * multiplier);
	}

	void OnGUI() {
		GUI.Label (new Rect (0, 0, 100f, 100f), "" + points);
	}

	void timeChange() {
		time += 0.05f;
		Time.timeScale = time;
		if (time < 3f)
			Invoke ("timeChange", time);
	}
}
