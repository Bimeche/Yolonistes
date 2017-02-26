using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
	public AudioSource music;

    // Use this for initialization
    void Start () {
		DontDestroyOnLoad(music);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickPlay()
    {
        SceneManager.LoadScene("Exposition");
    }
    public void ClickQuit()
    {
	
        Application.Quit();
    }

    public void ClickCredits()
    {
		Destroy(music);
        SceneManager.LoadScene("Joelle");
    }
}
