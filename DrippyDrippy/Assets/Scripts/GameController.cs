using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GUIStyle ggStyle;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}


	void OnGUI() {
		if (player.GetComponent<PlayerController> ().gameOver) {
			gameOver();
		}
	}

	void gameOver() {
		GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "GAME OVER", ggStyle);
	}
	

}
