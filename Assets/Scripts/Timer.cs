using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    Text myText;
    Image hd;
    Image hu;
    Image md;
    Image mu;
    public Sprite i0;
    public Sprite i1;
    public Sprite i2;
    public Sprite i3;
    public Sprite i4;
    public Sprite i5;
    public Sprite i6;
    public Sprite i7;
    public Sprite i8;
    public Sprite i9;

    int heure;
    int minutes;
    int dh = 0;
    int uh = 8;
    int dm = 0;
    int um = 0;

    // Use this for initialization
    void Start () {
        hd = GameObject.Find("HeureD").GetComponent<Image>();
        hu = GameObject.Find("HeureU").GetComponent<Image>();
        md = GameObject.Find("MinutesD").GetComponent<Image>();
        mu = GameObject.Find("MinutesU").GetComponent<Image>();
         dh = 0;
         uh = 8;
         dm = 0;
         um = 0;
        heure = 8;
        minutes = 0;
	}
	
	void Update () {
     //   ChangeTime(0, 1);
	}

	public int GetHeure()
	{
		return dh * 10 + uh;
	}

    public void ChangeTime(int AddHeure, int AddMinutes)
    {

        um = um + AddMinutes;
        while (um > 9)
        {
            dm++;
            um = um - 10;
        }

        if (dm > 5)
        {
            uh++;
            dm = dm - 6;
        }

        uh = uh + AddHeure;
        if (uh > 9)
        {
            dh++;
            uh = uh - 10;
        }

        applySprite(dh, hd);
        applySprite(uh, hu);
        applySprite(dm, md);
        applySprite(um, mu);

    }

    void applySprite(int num, Image spr)
    {
        switch (num)
        {
            case 0:
                spr.sprite = i0;
                break;
            case 1:
                spr.sprite = i1;
                break;
            case 2:
                spr.sprite = i2;
                break;
            case 3:
                spr.sprite = i3;
                break;
            case 4:
                spr.sprite = i4;
                break;
            case 5:
                spr.sprite = i5;
                break;
            case 6:
                spr.sprite = i6;
                break;
            case 7:
                spr.sprite = i7;
                break;
            case 8:
                spr.sprite = i8;
                break;
            case 9:
                spr.sprite = i9;
                break;


            default:
                spr.sprite = i0;
                break;
        }
    }

    
}
