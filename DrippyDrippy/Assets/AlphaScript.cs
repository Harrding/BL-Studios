using UnityEngine;
using System.Collections;

public class AlphaScript : MonoBehaviour {
	Color ccolor = new Color (1f,1f,1f,0f);
	float newalpha = 0f;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = ccolor;
		Invoke ("Brighten", 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Brighten () {
		if (newalpha < 0.9f)
			newalpha = newalpha + 0.1f;
		else
			newalpha = 1f;
		ccolor = new Color (1f, 1f, 1f, newalpha);
		gameObject.renderer.material.color = ccolor;
		if (newalpha < 1f) {
			Invoke ("Brighten", 0.1f);
		}
		else {
			Invoke ("ChangeScene", 1f);
		}
	}

	void ChangeScene() {
		Application.LoadLevel ("MenuScene");
	}
}
