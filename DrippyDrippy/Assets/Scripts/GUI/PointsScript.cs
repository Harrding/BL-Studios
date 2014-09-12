using UnityEngine;
using System.Collections;

public class PointsScript : MonoBehaviour {
	public GameObject clicker;
	public GUISkin normal;
	public Texture2D pausebut, pausebutover;
	public int points;
	public float multiplier, time;
	public bool paused = false;
	//
	// Use this for initialization
	void Start () {
		clicker = GameObject.FindGameObjectWithTag ("Click");
		//time = 0.1f;
		points = 0;
		multiplier = 200;
		Time.timeScale = 2f;
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
		GUI.Box (new Rect (Screen.width / 8, Screen.height / 50, Screen.width - Screen.width / 4, Screen.height / 12 + Screen.height / 50), "" + points, boxfont);
		GUIStyle buttonfont = new GUIStyle (GUI.skin.button);
		buttonfont.normal.background = pausebut;
		buttonfont.hover.background = pausebutover;
		buttonfont.active.background = pausebutover;
		if (GUI.Button (new Rect (Screen.width - Screen.width / 9, Screen.height / 50, Screen.width / 9, Screen.width / 9), "", buttonfont) && paused == false) {
			clicker.gameObject.GetComponent<AudioSource>().Play();
			paused = true;
			Time.timeScale = 0f;
		}
		if (paused == true) {
			GUI.Box (new Rect(-10,-10,Screen.width + 20,Screen.height + 20), "");
			GUI.Box (new Rect(-10,-10,Screen.width + 20,Screen.height + 20), "");
			GUI.Box (new Rect(-10,-10,Screen.width + 20,Screen.height + 20), "");
			GUI.Box (new Rect(-10,-10,Screen.width + 20,Screen.height + 20), "");
			GUIStyle labelfont = new GUIStyle (GUI.skin.label);
			labelfont.fontSize = Screen.height / 8;
			labelfont.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect(0, 0, Screen.width, Screen.height - Screen.height / 8), "Paused", labelfont);
			GUIStyle buttonfont2 = new GUIStyle (GUI.skin.button);
			buttonfont2.fontSize = Screen.height / 18;
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 4, Screen.width * 2 / 3, Screen.height / 8), "Resume", buttonfont2)) {
				clicker.gameObject.GetComponent<AudioSource>().Play();
				paused = false;
				Time.timeScale = 2f;
			}
		}
		GUI.EndGroup ();
	}

	/*void timeChange() {
		time += 0.05f;
		Time.timeScale = time;
		if (time < 3f)
			Invoke ("timeChange", time);
	}*/
}
