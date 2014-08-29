using UnityEngine;
using System.Collections;

public class CaravanStats : MonoBehaviour {
	public int gold;
	public ArrayList inventory = new ArrayList();
	public ArrayList amount = new ArrayList();
	public Vector2 scrollPosition = Vector2.zero;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			inventory.Add (0);
			amount.Add (100);
		}
	}

	void OnGUI() {
		GUI.BeginGroup (new Rect (0, 0, Screen.width, Screen.height));
		GUI.Box (new Rect (-10, -10, Screen.width / 4 + 10, Screen.height + 20), "");
		GUI.Box (new Rect (10, Screen.height / 4, Screen.width / 4 - 20, Screen.height / 16), "" + gold);
		GUI.Box (new Rect (10, Screen.height / 4 + Screen.height / 16 + 10, Screen.width / 4 - 20, Screen.height - Screen.height / 4 - Screen.height / 16 - 20), "");
		scrollPosition = GUI.BeginScrollView(new Rect(10, Screen.height / 4 + Screen.height / 16 + 10, Screen.width / 4 - 20, Screen.height - Screen.height / 4 - Screen.height / 16 - 20), scrollPosition, new Rect(0, 0, 0, (inventory.Count + 1) / 2 * (Screen.width / 8 - 20) + 10));
		for (int i = 0; i < inventory.Count; i++) {
			GUI.Box (new Rect (10 + i % 2 * (Screen.width / 8 - 20), i / 2 * (Screen.width / 8 - 20) + 10, Screen.width / 8 - 30, Screen.width / 8 - 30),"");
		}
		GUI.EndScrollView ();
		GUI.EndGroup ();
	}
}
