using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InvestigationEndScript : MonoBehaviour {


    public Image image;

    public Sprite image1;

    int slide;
    int slideMax = 1;

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
            SceneManager.LoadScene("MainMenu");
        }
    }
}
