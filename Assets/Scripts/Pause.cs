using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public Image p;
	public Image blockingPanel;
    public Button play;
    public Button quit;
	public AudioSource pauseMusic;
    private bool isPause = false;

    // Use this for initialization
    void Start () {
     
        p.gameObject.SetActive(false);
        play.gameObject.SetActive (false);
        quit.gameObject.SetActive(false);

		pauseMusic = GameObject.Find("backgroundMusic").GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPause)
			{
				blockingPanel.GetComponent<CanvasGroup>().alpha = 0;
				blockingPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
				p.gameObject.SetActive(false);
                play.gameObject.SetActive(false);
                quit.gameObject.SetActive(false);
                Time.timeScale = 1;
                isPause = false;
				pauseMusic.Play();
               
            }
            else
			{
				blockingPanel.GetComponent<CanvasGroup>().alpha = 1;
				blockingPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
				p.gameObject.SetActive(true);
                play.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
				pauseMusic.Pause();

            }
               
        }
    }

    public void ClickPlay()
	{
		blockingPanel.GetComponent<CanvasGroup>().alpha = 0;
		blockingPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		p.gameObject.SetActive(false);
        isPause = false;
        play.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        Time.timeScale = 1;
		pauseMusic.Play();
    }
    public void ClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
