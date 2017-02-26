using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workers : MonoBehaviour {

    public int number;
    CurrentFloder currentF;
    // Use this for initialization
    void Start () {
        currentF = GameObject.Find("CurrentFolder").GetComponent<CurrentFloder>();
        if (currentF.isDead(number))
            gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
