using UnityEditor;
using UnityEngine;

public class ProfilePage : MonoBehaviour {
	private SpriteRenderer rend;
	public bool isZoomed;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/TestSprite.png");
		rend.sprite = sprite;
		isZoomed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ZoomOut()
	{
		isZoomed = false;
		rend.enabled = false;
	}

	public void ZoomIn()
	{
		isZoomed = true;
		rend.enabled = true;
	}
}
