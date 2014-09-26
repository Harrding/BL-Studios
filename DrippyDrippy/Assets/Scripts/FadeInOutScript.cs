using UnityEngine;
using System.Collections;

public class FadeInOutScript : MonoBehaviour {
	Color ccolor = new Color (1f,1f,1f,0f);
	float newalpha = 0f;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.color = ccolor;
		Invoke ("Brighten", 0.05f);
	}

	void Update () {
	
	}
	void Brighten() {
		if (newalpha > .05f)
			newalpha = newalpha - 0.05f;
		else
			newalpha = 0f;
		ccolor = new Color (1f, 1f, 1f, newalpha);
		gameObject.renderer.material.color = ccolor;
		if (newalpha < 1f) {
			Invoke ("Brighten", 0.05f);
		}
	}
	bool Darken () {
		if (newalpha < 0.95f)
			newalpha = newalpha + 0.05f;
		else
			newalpha = 1f;
		ccolor = new Color (1f, 1f, 1f, newalpha);
		gameObject.renderer.material.color = ccolor;
		if (newalpha < 1f) {
			Invoke ("Darken", 0.05f);
		}
		else {
			return true;
		}
		return false;
	}
}
