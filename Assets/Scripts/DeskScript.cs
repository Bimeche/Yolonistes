using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskScript : MonoBehaviour
{
	private PageScript page;
	private ProfilePage profile;
	// Use this for initialization
	void Start()
	{
		page = GetComponentInChildren<PageScript>();
		profile = GetComponentInChildren<ProfilePage>();
	}
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			CastRay();
		}
	}

	void CastRay()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
		switch (hit.collider.gameObject.name)
		{
			case "Page":
				page.ZoomIn();
				profile.ZoomIn();
				break;
			case "Background":
				page.ZoomOut();
				profile.ZoomOut();
				break;
			case "ProfilePage":
				break;
		}
	}
}
