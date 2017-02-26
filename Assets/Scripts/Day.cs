using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Day : MonoBehaviour {

	private CurrentFloder currentFo;
	float timeArchive;

	// Use this for initialization
	void Start () {
		currentFo  = GameObject.Find("CurrentFolder").GetComponent<CurrentFloder>();
		GetComponent<Text>().text = "DAY " + currentFo.day.ToString();
		timeArchive = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ( timeArchive + 1.5 < Time.time)
		{
			GetComponent<Text>().text = "";

		}
	}
}
