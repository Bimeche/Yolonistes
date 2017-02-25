using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Office : MonoBehaviour {

    public SpriteRenderer bubble;
    private bool isHere = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && isHere)
        {
            Debug.Log("E2");
            SceneManager.LoadScene("Leo");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        bubble.enabled = true;
        Debug.Log("Enter");
        isHere = true;
    }


    void OnTriggerExit2D(Collider2D other)
    {
        bubble.enabled = false;
        Debug.Log("Exit");
        isHere = false;
    }

}
