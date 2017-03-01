using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoodGuyScript : MonoBehaviour {
    private CurrentFloder currF;

    public Image image;

    public Sprite image1;
    public Sprite image2;

    public Text text;

    int slide;
    int slideMax = 2;

    // Use this for initialization
    void Start()
    {
        slide = 0;
        currF = GameObject.Find("CurrentFolder").GetComponent<CurrentFloder>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (slide)
        {
            case 1:
                image.sprite = image1;
                break;
            case 2:
                image.sprite = image2;
                Debug.Log("ok");
                if(currF.Files.listCharacters[0].guilty)
                {
                    text.text = "That file could have been mine...";
                    Debug.Log("guilt");
                }
                else
                {
                    text.text = "Yay it's the week end!";
                    Debug.Log("no guilt");
                }
                break;
            default:
                break;
        }

    }


    public void ClickForward()
    {
        if (slide < slideMax)
        {
            slide++;
        }
        else if (slide == slideMax)
        {
			Destroy(GameObject.Find("CurrentFolder").GetComponent<CurrentFloder>().gameObject);
			Destroy(GameObject.Find("FileReader").GetComponent<FileReader>().gameObject);
			Destroy(GameObject.Find("SoundManager").GetComponent<SoundManager>().gameObject);
			Destroy(GameObject.Find("backgroundMusic"));
			SceneManager.LoadScene("MainMenu");
        }
    }
}
