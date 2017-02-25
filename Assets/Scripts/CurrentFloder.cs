using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentFloder : MonoBehaviour {
    public FileReader Files;
    CharacterInfos current;
    int index;
	// Use this for initialization
	void Start () {
       // Files = new FileReader();
       current = Files.listCharacters[1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public CharacterInfos GetCurrent()
    {
        return current;
    }
    public void NextFile()
    {
        index++;
        current = Files.listCharacters[index];
    }

}
