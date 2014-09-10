using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour {
	public GUISkin normal;
	public GameObject newscoresound, clicker;

	// Use this for initialization
	void Start () {
		newscoresound = GameObject.FindGameObjectWithTag ("NewScore");
		clicker = GameObject.FindGameObjectWithTag ("Click");
		if (MasterClass.musicon == false) {
			if (MasterClass.newhighscore == true) {
				newscoresound.GetComponent<AudioSource>().Play();
			}
			else {
				gameObject.GetComponent<AudioSource>().Play();
			}
		}
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
		GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 2 / 18,Screen.width, Screen.height / 14), "Highest Score", labelfont);
		GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 5 / 18,Screen.width, Screen.height / 14), "Most Powerups Collected", labelfont);
		GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 8 / 18,Screen.width, Screen.height / 14), "Most Logs Crashed", labelfont);
		labelfont.normal.textColor = new Color (255f,255f,0f);
		if (MasterClass.newhighscore == true)
			GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 1 / 18,Screen.width, Screen.height / 14), "NEW HIGH SCORE!", labelfont);
		GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 3 / 18,Screen.width, Screen.height / 14), "" + MasterClass.getHighestScore(), labelfont);
		GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 6 / 18,Screen.width, Screen.height / 14), "" + MasterClass.getPUCollected(), labelfont);
		GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 9 / 18,Screen.width, Screen.height / 14), "" + MasterClass.getObstaclesHit(), labelfont);
		GUIStyle buttonfont = new GUIStyle (GUI.skin.button);
		buttonfont.fontSize = Screen.height / 18;
		if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 4 + Screen.height / 8, Screen.width * 2 / 3, Screen.height / 8), "Back", buttonfont)) {
			clicker.gameObject.GetComponent<AudioSource>().Play();
			if (MasterClass.musicon == true) {
				Application.LoadLevel ("MenuScene");
			}
			else {
				Application.LoadLevel ("TempScene");
			}
			MasterClass.musicon = true;
			MasterClass.newhighscore = false;
		}
		GUI.EndGroup ();
	}
}
