using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : MonoBehaviour {

    Informations baseDocument;
    int number;
    Archive archive;
    int status; //1 New, 2 Returning  selected as Non Guilty, 3 Investigated selected as To investigate, 4 Completed 
    int playerChoice; //1 No choice yet,  2 Non Guilty, 3 Investigate, 4 Guilty
    bool isGuilty;

    // Use this for initialization
    void Start () {
        status = 1;
        playerChoice = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
