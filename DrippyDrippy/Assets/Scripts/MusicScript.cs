using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		Application.LoadLevel ("MenuScene");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
