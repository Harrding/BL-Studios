using UnityEngine;
using System.Collections;

public class CaravanStats : MonoBehaviour {
	public int gold;
	int margin, value;
	public ArrayList inventory = new ArrayList();
	public ArrayList amount = new ArrayList();
	public Vector2 scrollPosition = Vector2.zero;

	// Use this for initialization
	void Start () {
		margin = 0;
		value = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			addNewItem(0,value);
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			value += 1000;
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			value += 1000000;
		}
	}

	public void addNewItem(int index, int quantity) {
		inventory.Add (index);
		amount.Add (quantity);
		if ((inventory.Count + 1) / 2 * (Screen.width / 8 - 20) + 10 > Screen.height - Screen.height / 4 - Screen.height / 16 - 20) {
			margin = 0;
		}
		else {
			margin = 5;
		}
	}

	void OnGUI() {
		GUI.BeginGroup (new Rect (0, 0, Screen.width, Screen.height));
		GUI.Box (new Rect (-10, -10, Screen.width / 4 + 10, Screen.height + 20), "");
		GUI.Box (new Rect (10, Screen.height / 4, Screen.width / 4 - 20, Screen.height / 16), "" + gold);
		GUI.Box (new Rect (10, Screen.height / 4 + Screen.height / 16 + 10, Screen.width / 4 - 20, Screen.height - Screen.height / 4 - Screen.height / 16 - 20), "");
		scrollPosition = GUI.BeginScrollView(new Rect(10, Screen.height / 4 + Screen.height / 16 + 10, Screen.width / 4 - 20, Screen.height - Screen.height / 4 - Screen.height / 16 - 20), scrollPosition, new Rect(0, 0, 0, (inventory.Count + 1) / 2 * (Screen.width / 8 - 20) + 10));
		for (int i = 0; i < inventory.Count; i++) {
			GUI.Box (new Rect (10 + i % 2 * (Screen.width / 8 - 20) + margin, i / 2 * (Screen.width / 8 - 20) + 10, Screen.width / 8 - 30, Screen.width / 8 - 30),"");
			GUI.Box (new Rect (10 + i % 2 * (Screen.width / 8 - 20) + margin, i / 2 * (Screen.width / 8 - 20) + 10 + (Screen.width / 8 - 30) * 2 / 3, Screen.width / 8 - 30, (Screen.width / 8 - 30) / 3),new GUIContent(sNum((int)amount[i]), "" + (int)amount[i]));
		}
		GUI.EndScrollView ();
		if (GUI.tooltip != "") {
			GUI.Box (new Rect(Input.mousePosition.x,(Screen.height - Input.mousePosition.y) - Screen.width / 32,Screen.width / 4, Screen.width / 32), GUI.tooltip);
		}
		GUI.EndGroup ();
	}

	string sNum(int num) {
		string newnum = "" + num;
		if (num >= 10000 && num < 1000000) {
			newnum = (num / 1000) + "K";
		}
		if (num >= 1000000 && num < 1000000000) {
			newnum = (num / 1000000) + "M";
		}
		if (num >= 1000000000) {
			newnum = (num / 1000000000) + "B";
		}
		return newnum;
	}
}
