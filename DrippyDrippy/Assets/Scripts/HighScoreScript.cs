using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour {
	public GUISkin normal;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
		GUI.skin = normal;
		GUI.Box (new Rect (-10, -10, Screen.width + 20, Screen.height + 20), "");
		GUIStyle labelfont = new GUIStyle (GUI.skin.label);
		labelfont.fontSize = Screen.height / 12;
		labelfont.alignment = TextAnchor.UpperCenter;
		GUI.Label (new Rect(0,Screen.height / 50,Screen.width,Screen.height / 8), "High Scores", labelfont);
		labelfont.fontSize = Screen.height / 18;
		GUI.Label (new Rect(0,Screen.height / 8 + Screen.height / 6,Screen.width, Screen.height / 12), "No Score Feature", labelfont);
		GUIStyle buttonfont = new GUIStyle (GUI.skin.button);
		buttonfont.fontSize = Screen.height / 18;
		if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 4 + Screen.height / 8, Screen.width * 2 / 3, Screen.height / 8), "Back", buttonfont)) {
			Application.LoadLevel ("MenuScene");
		}
		GUI.EndGroup ();
	}
}
