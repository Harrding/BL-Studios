using UnityEngine;
using System.Collections;

public class InfoScript : MonoBehaviour {
	public GUISkin normal;
	public string[] lines;
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
		GUIStyle labelfont = new GUIStyle (GUI.skin.label);
		labelfont.fontSize = Screen.height / 12;
		labelfont.alignment = TextAnchor.UpperCenter;
		GUI.Label (new Rect(0,Screen.height / 50,Screen.width,Screen.height / 8), "Credits", labelfont);
		labelfont.fontSize = Screen.height / 28;
		for (int i = 0; i < lines.Length; i++) {
			GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * i / 26,Screen.width, Screen.height / 24), lines[i], labelfont);
		}
		GUIStyle buttonfont = new GUIStyle (GUI.skin.button);
		buttonfont.fontSize = Screen.height / 18;
		if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 4 + Screen.height / 8, Screen.width * 2 / 3, Screen.height / 8), "Back", buttonfont)) {
			clicker.gameObject.GetComponent<AudioSource>().Play();
			Application.LoadLevel ("MenuScene");
		}
		GUI.EndGroup ();
	}
}
