using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public Image p;
    public Button play;
    public Button quit;
    private bool isPause = false;

    // Use this for initialization
    void Start () {
     
        p.gameObject.SetActive(false);
        play.gameObject.SetActive (false);
        quit.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPause)
            {
                p.gameObject.SetActive(false);
                play.gameObject.SetActive(false);
                quit.gameObject.SetActive(false);
                Time.timeScale = 1;
                isPause = false;
               
               
            }
            else
            {
                p.gameObject.SetActive(true);
                play.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
            }
               
        }
    }

    public void ClickPlay()
    {
        p.gameObject.SetActive(false);
        isPause = false;
        play.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
