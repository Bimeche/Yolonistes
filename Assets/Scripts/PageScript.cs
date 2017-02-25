using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScript : MonoBehaviour {
	private bool isZoomed;
	public Transform profilePagePrefab;

	// Use this for initialization
	void Start () {
		isZoomed = false;
	}
	// Update is called once per frame
	void Update () {
	}
	
	public void ZoomIn()
	{
		Vector3 profilePagePos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2 - 100, 9f));
		Instantiate(profilePagePrefab, profilePagePos, Quaternion.identity, transform.parent);
	}

	public void ZoomOut()
	{
		isZoomed = false;
	}
}
