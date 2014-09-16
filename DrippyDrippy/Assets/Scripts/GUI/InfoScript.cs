using UnityEngine;
using System.Collections;

public class InfoScript : MonoBehaviour {
	public GUISkin normal;
	public string[] lines;
	public GameObject clicker;
	Vector2 scrollPosition;
	Touch touch;
	
	// Use this for initialization
	void Start () {
		clicker = GameObject.FindGameObjectWithTag ("Click");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			touch = Input.touches[0];
			if (touch.phase == TouchPhase.Moved) {
				scrollPosition.y += touch.deltaPosition.y;
			}
		}
	}
	
	void OnGUI () {
		GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
		GUI.skin = normal;
		GUI.Box (new Rect (-10, -10, Screen.width + 20, Screen.height + 20), "");
		GUIStyle labelfont = new GUIStyle (GUI.skin.label);
		labelfont.fontSize = Screen.height / 12;
		labelfont.alignment = TextAnchor.UpperCenter;
		GUI.Label (new Rect(0,Screen.height / 50,Screen.width,Screen.height / 8), "Credits", labelfont);
		labelfont.fontSize = Screen.height / 20;
		GUI.Box (new Rect (Screen.width / 50, Screen.height / 8 - Screen.height / 50, Screen.width - Screen.width / 25, Screen.height - Screen.height / 4 - Screen.height / 8 + Screen.height / 50), "");
		scrollPosition = GUI.BeginScrollView (new Rect (0,Screen.height / 8,Screen.width + 200,Screen.height - Screen.height / 4 - Screen.height / 8 - Screen.height / 50), scrollPosition, new Rect (0, 0, 0, Screen.height * lines.Length / 20));
		for (int i = 0; i < lines.Length; i++) {
			if (lines[i].StartsWith ("~")) {
				labelfont.normal.textColor = new Color(255f,255f,0f);
				labelfont.fontSize = Screen.height / 20;
				GUI.Label (new Rect(0,Screen.height * i / 20,Screen.width, Screen.height / 18), lines[i].Substring (1), labelfont);
			}
			else {
				labelfont.normal.textColor = new Color(255f,255f,255f);
				labelfont.fontSize = Screen.height / 22;
				GUI.Label (new Rect(0,Screen.height * i / 20,Screen.width, Screen.height / 18), lines[i], labelfont);
			}
		}
		GUI.EndScrollView ();
		GUIStyle buttonfont = new GUIStyle (GUI.skin.button);
		buttonfont.fontSize = Screen.height / 18;
		if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 4, Screen.width * 2 / 3, Screen.height / 8), "Back", buttonfont)) {
			clicker.gameObject.GetComponent<AudioSource>().Play();
			Application.LoadLevel ("MenuScene");
		}
		GUI.EndGroup ();
	}
}
