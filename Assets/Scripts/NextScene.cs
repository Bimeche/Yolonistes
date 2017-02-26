using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
	public AudioSource music;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(music);
		SceneManager.LoadScene("Morgane");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
