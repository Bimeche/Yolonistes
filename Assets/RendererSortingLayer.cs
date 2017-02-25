using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererSortingLayer : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		
	}
    
    // Use this for initialization
    void Start()
    {
        
        this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 50;

    }
}
