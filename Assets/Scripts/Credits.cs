using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour {
	public AudioSource creditsMusic;
    public Text t1;
    public Text t2;
    public Text t3;
    public Text texte;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ClickAssets()
    {
        t1.text = "";
        t2.text = "";
        t3.text = "";

        texte.text = "Game Sprites adapted from: \n Pokemon HeartGold SoulSilver – DS, Pokemon Diamond Pearl – DS, Stardew Valley – PC, Army Men Advance – GBA, Papers, Please – PC, noirlac.tumblr.com \nMusic: \nTaylor Davis -Sadness and Sorrow, Ofelia’s Dream. \nSounds from freesound.com and Papers, Please.";
    }

    public void ClickBack()
    {
		creditsMusic.Stop();
        SceneManager.LoadScene("MainMenu");
    }
}
