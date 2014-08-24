using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
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
		GUIStyle buttonfont = new GUIStyle (GUI.skin.button);
		buttonfont.fontSize = Screen.height / 18;
		if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 16, Screen.width * 2 / 3, Screen.height / 8), "Play", buttonfont)) {
			Application.LoadLevel ("GameScene");
		}
		GUI.Button (new Rect(Screen.width / 2 - Screen.width / 3,Screen.height / 2 - Screen.height / 16 + Screen.height / 8 + Screen.height / 64, Screen.width * 2 / 3, Screen.height / 8),"High Scores", buttonfont);
		GUI.EndGroup ();
	}
}
