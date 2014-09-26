using UnityEngine;
using System.Collections;

public class MusicScript2 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		Application.LoadLevel ("GameScene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
