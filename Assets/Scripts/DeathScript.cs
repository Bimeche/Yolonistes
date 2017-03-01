using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour {

    public Image image;

    public Sprite image1;
    public Sprite image2;

    int slide;
    int slideMax = 2;

    // Use this for initialization
    void Start()
    {
        slide = 0;
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
