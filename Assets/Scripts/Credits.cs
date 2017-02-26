using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
	public AudioSource creditsMusic;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickBack()
    {
		creditsMusic.Stop();
        SceneManager.LoadScene("MainMenu");
    }
}
