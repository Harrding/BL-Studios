using UnityEngine;
using System.Collections;

public class PointsScript : MonoBehaviour {
	public GameObject clicker, newscoresound, musicobj;
	public GUISkin normal;
	public Texture2D pausebut, pausebutover;
	public int points, logs, powerups;
	public float multiplier, time, pointsize = 0;
	public bool paused = false, activated = false;

	private int level, newlevelstate;
	private GameObject player;
	//
	// Use this for initialization
	void Start () {
		clicker = GameObject.FindGameObjectWithTag ("Click");
		newscoresound = GameObject.FindGameObjectWithTag ("NewScore");
		musicobj = GameObject.FindGameObjectWithTag ("Music");
		//time = 0.1f;
		points = 0;
		logs = 0;
		powerups = 0;
		multiplier = 200;
		Time.timeScale = 2f;
		player = GameObject.FindGameObjectWithTag ("Player");
		level = 0;
		incrementLevel ();
		//Time.timeScale = time;
		//Invoke ("timeChange",time);
	}
	
	// Update is called once per frame
	void Update () {
		if (activated == false)
			points += (int)(Time.deltaTime * multiplier);
		if(points > (level * MasterClass.PPLEVEL + Mathf.Pow (2f,level - 1) * 2000) && level < 5) {
			//Display new level GUI
			incrementLevel();
		}
		if (newlevelstate == 1) {
			if (pointsize < Screen.height / 4) {
				pointsize += Screen.height / 400 * Time.fixedDeltaTime * 120;
			}
			else {
				pointsize = Screen.height / 4;
				newlevelstate = 2;
			}
		}
		if (newlevelstate == 2) {
			if (pointsize > 0) {
				pointsize -= Screen.height / 400 * Time.fixedDeltaTime * 120;
			}
			else {
				pointsize = 0;
				newlevelstate = 0;
			}
		}
	}
	void incrementLevel() {
		level++;
		newlevelstate = 1;
		player.SendMessage ("incrementLevel");
	}

	public void playSound () {
		if (MasterClass.musicon == false) {
			if (MasterClass.newhighscore == true) {
				newscoresound.GetComponent<AudioSource>().Play();
			}
			else {
				gameObject.GetComponent<AudioSource>().Play();
			}
		}
	}

	public void activateDeath(int currentlogs, int currentpowerups) {
		activated = true;
		Time.timeScale = 2f;
		paused = false;
		logs = currentlogs;
		powerups = currentpowerups;
		playSound ();
	}

	void OnGUI() {
		if (activated == false) {
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
				musicobj.gameObject.GetComponent<AudioSource>().Pause();
				paused = true;
				Time.timeScale = 0f;
			}
			GUIStyle labelfont = new GUIStyle (GUI.skin.label);
			labelfont.fontSize = (int)pointsize;
			labelfont.alignment = TextAnchor.MiddleCenter;
			if (pointsize != 0)
				GUI.Label (new Rect (0,Screen.height / 50 + Screen.width / 9,Screen.width,Screen.height - Screen.height / 50 - Screen.width / 9), "Level" + level, labelfont);
			if (paused == true) {
				GUI.Box (new Rect(-10,-10,Screen.width + 20,Screen.height + 20), "");
				GUI.Box (new Rect(-10,-10,Screen.width + 20,Screen.height + 20), "");
				GUI.Box (new Rect(-10,-10,Screen.width + 20,Screen.height + 20), "");
				labelfont.fontSize = Screen.height / 8;
				labelfont.alignment = TextAnchor.MiddleCenter;
				GUI.Label (new Rect(0, 0, Screen.width, Screen.height - Screen.height / 8), "Paused", labelfont);
				GUIStyle buttonfont2 = new GUIStyle (GUI.skin.button);
				buttonfont2.fontSize = Screen.height / 18;
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 8, Screen.width * 2 / 3, Screen.height / 8), "Resume", buttonfont2)) {
					clicker.gameObject.GetComponent<AudioSource>().Play();
					musicobj.gameObject.GetComponent<AudioSource>().Play();
					paused = false;
					Time.timeScale = 2f;
				}
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 4, Screen.width * 2 / 3, Screen.height / 8), "Menu", buttonfont2)) {
					clicker.gameObject.GetComponent<AudioSource>().Play();
					Destroy (musicobj);
					paused = false;
					Time.timeScale = 2f;
					Application.LoadLevel ("TempScene");
				}
			}
			GUI.EndGroup ();
		}
		else {
			GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
			GUI.skin = normal;
			GUI.Box (new Rect (-10, -10, Screen.width + 20, Screen.height + 20), "");
			GUIStyle labelfont = new GUIStyle (GUI.skin.label);
			labelfont.fontSize = Screen.height / 12;
			labelfont.alignment = TextAnchor.UpperCenter;
			GUI.Label (new Rect(0,Screen.height / 50,Screen.width,Screen.height / 8), "Out of Water!", labelfont);
			labelfont.fontSize = Screen.height / 18;
			GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 1 / 18,Screen.width, Screen.height / 14), "Score", labelfont);
			GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 4 / 18,Screen.width, Screen.height / 14), "Powerups Collected", labelfont);
			GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 7 / 18,Screen.width, Screen.height / 14), "Logs Crashed", labelfont);
			labelfont.normal.textColor = new Color (255f,255f,0f);
			if (MasterClass.newhighscore == true)
				GUI.Label (new Rect(0,Screen.height / 8,Screen.width, Screen.height / 14), "NEW HIGH SCORE!", labelfont);
			GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 2 / 18,Screen.width, Screen.height / 14), "" + points, labelfont);
			GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 5 / 18,Screen.width, Screen.height / 14), "" + powerups, labelfont);
			GUI.Label (new Rect(0,Screen.height / 8 + Screen.height * 8 / 18,Screen.width, Screen.height / 14), "" + logs, labelfont);
			GUIStyle buttonfont = new GUIStyle (GUI.skin.button);
			buttonfont.fontSize = Screen.height / 18;
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 8, Screen.width * 2 / 3, Screen.height / 8), "Retry", buttonfont)) {
				clicker.gameObject.GetComponent<AudioSource>().Play();
				MasterClass.newhighscore = false;
				Application.LoadLevel ("TempScene2");
			}
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 4, Screen.width * 2 / 3, Screen.height / 8), "High Scores", buttonfont)) {
				clicker.gameObject.GetComponent<AudioSource>().Play();
				MasterClass.newhighscore = false;
				Application.LoadLevel ("HighScoreScene");
			}
			GUI.EndGroup ();
		}
	}

	/*void timeChange() {
		time += 0.05f;
		Time.timeScale = time;
		if (time < 3f)
			Invoke ("timeChange", time);
	}*/
}
