using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
    // Use this for initialization
    void Start () {
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
        SceneManager.LoadScene("Joelle");
    }
}
