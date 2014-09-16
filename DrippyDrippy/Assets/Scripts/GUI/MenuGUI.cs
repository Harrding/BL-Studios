using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	public GUISkin normal;
	public Texture2D title, infobut1, infobut2;
	public GameObject clicker;

	// Use this for initialization
	void Start () {
		clicker = GameObject.FindGameObjectWithTag ("Click");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
		GUI.skin = normal;
		GUI.Box (new Rect (-10, -10, Screen.width + 20, Screen.height + 20), "");
		GUIStyle boxfont = new GUIStyle (GUI.skin.label);
		boxfont.alignment = TextAnchor.MiddleCenter;
		boxfont.normal.background = title;
		GUI.Box (new Rect (Screen.width / 100, Screen.height / 40, Screen.width - Screen.width / 50, Screen.height / 2 - Screen.height / 20), "", boxfont);
		GUIStyle buttonfont = new GUIStyle (GUI.skin.button);
		buttonfont.fontSize = Screen.height / 18;
		if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 8, Screen.width * 2 / 3, Screen.height / 8), "Play", buttonfont)) {
			clicker.gameObject.GetComponent<AudioSource>().Play();
			Application.LoadLevel ("GameScene");
		}
		if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 4, Screen.width * 2 / 3, Screen.height / 8), "High Scores", buttonfont)) {
			clicker.gameObject.GetComponent<AudioSource>().Play();
			Application.LoadLevel ("HighScoreScene");
		}
		buttonfont.normal.background = infobut1;
		buttonfont.hover.background = infobut2;
		buttonfont.active.background = infobut2;
		if (GUI.Button (new Rect(Screen.width - Screen.width / 9, Screen.height - Screen.width / 9, Screen.width / 10, Screen.width / 10), "", buttonfont)) {
			clicker.gameObject.GetComponent<AudioSource>().Play();
			Application.LoadLevel ("InfoScene");
		}
		GUI.EndGroup ();
	}
}
