using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentFloder : MonoBehaviour {
    public FileReader Files;
    CharacterInfos current;
    int index = 1;
    public GameObject g;
    
	// Use this for initialization
	void Start () {
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    public CharacterInfos GetCurrent()
    {
        current = Files.listCharacters[index];
        return current;
    }
    public void NextFile()
    {
        index++;
        Debug.Log("Count " + Files.listCharacters.Count + " index " +index);
        current = Files.listCharacters[index];
    }

}
