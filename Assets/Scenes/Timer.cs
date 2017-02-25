using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    Text myText;
    int heure;
    int minutes;

    // Use this for initialization
    void Start () {
        myText = GetComponent<Text>();
        myText.text = "08 : 00";
        heure = 8;
        minutes = 0;
	}
	
	// Update is called once per frame
	void Update () {
       // ChangeTime(0, 1);
        
	}

    public void ChangeTime(int AddHeure, int AddMinutes)
    {
        minutes = minutes + AddMinutes;
        if (minutes >= 60)
        {
            minutes = minutes - 60;
            heure++;
        }

        heure = heure + AddHeure;

        string HString;
        if (heure < 10)
            HString = "0" + heure.ToString();
        else
            HString = heure.ToString();

        string MString;
        if (minutes < 10)
            MString = "0" + minutes.ToString();
        else
            MString = minutes.ToString();

        
            myText.text = HString + " : " + MString;

        if (heure >= 18)
            Debug.Log("End Day");

    }
}
