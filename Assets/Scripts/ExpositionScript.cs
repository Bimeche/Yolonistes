using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExpositionScript : MonoBehaviour {
    public Image image;
    public Text text;

    public Sprite image0;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;

    int slide;
    int slideMax = 5;

	// Use this for initialization
	void Start () {
        slide = 0;	
	}
	
	// Update is called once per frame
	void Update () {
        switch (slide)
        {
            case 0:
                image.sprite = image0;
                text.text = "2307: The population has skyrocketed, resulting in stricter regulations by the government. Crime is severely punished to ensure obedience and the conservation of the rapidly depleting resources.";
                break;
            case 1:
                image.sprite = image1;
                text.text = "You are a government official charged to judge citizens based on different files provided by Big Brother.";
                break;
            case 2:
                image.sprite = image2;
                text.text = "Every day, you have a quota of cases to judge. Pay attention to the clock or you may have to rush decisions.";
                break;
            case 3:
                image.sprite = image3;
                text.text = "You can look for more information in the archives, where you can access criminal records, financial reports and medical files. Consulting any of the three archives costs you time but could lead to a fairer decision. The archives close at 16:00 though.";
                break;
            case 4:
                image.sprite = image4;
                text.text = "When judging a file, you can ask for further investigation (in which case, you might judge the case again later on).";
                break;
            case 5:
                image.sprite = image5;
                text.text = "After your first day, you will receive a performance report each morning on your desk, letting you know how accurate your decisions have been the past day.";
                break;
            default:
                break;
        }

    }

    public void ClickBack()
    {
        if(slide>0)
        {
            slide--;
        }
    }

    public void ClickForward()
    {
        if(slide < slideMax)
        {
            slide++;
        }
        else if(slide == slideMax)
        {
            SceneManager.LoadScene("BeginMusicScene");
        }
    }
}
