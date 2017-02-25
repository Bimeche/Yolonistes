using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScript : MonoBehaviour {
	private SpriteRenderer rend;
	private bool isZoomed;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		rend.enabled = true;
		isZoomed = false;
	}
	// Update is called once per frame
	void Update () {
	}
	
	public void ZoomIn()
	{
		isZoomed = true;
		rend.enabled = false;
	}

	public void ZoomOut()
	{
		isZoomed = false;
		rend.enabled = true;
	}
}
