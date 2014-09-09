using UnityEngine;
using System.Collections;

public class PointsScript : MonoBehaviour {
	public GUISkin normal;
	public int points;
	public float multiplier, time;
	//
	// Use this for initialization
	void Start () {
		//time = 0.1f;
		points = 0;
		multiplier = 200;
		//Time.timeScale = time;
		//Invoke ("timeChange",time);
	}
	
	// Update is called once per frame
	void Update () {
		points += (int)(Time.deltaTime * multiplier);
	}

	void OnGUI() {
		GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
		GUI.skin = normal;
		GUIStyle boxfont = new GUIStyle (GUI.skin.box);
		boxfont.fontSize = Screen.height / 12;
		boxfont.alignment = TextAnchor.MiddleCenter;
		GUI.Box (new Rect (Screen.width / 50, Screen.height / 50, Screen.width - Screen.width / 25, Screen.height / 12 + Screen.height / 50), "" + points, boxfont);
		GUI.EndGroup ();
	}

	/*void timeChange() {
		time += 0.05f;
		Time.timeScale = time;
		if (time < 3f)
			Invoke ("timeChange", time);
	}*/
}
