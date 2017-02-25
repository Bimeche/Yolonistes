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
        Transform parent = transform.parent;

        Renderer parentRenderer = parent.GetComponent<Renderer>();
        Renderer renderer = GetComponent<Renderer>();
        renderer.sortingLayerID = parentRenderer.sortingLayerID;
        renderer.sortingOrder = parentRenderer.sortingOrder;

       
    }
}
