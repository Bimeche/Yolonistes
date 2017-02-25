using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informations : MonoBehaviour {

    public TextMesh numéro;
    public TextMesh age;
    public TextMesh genre;
    public TextMesh profession;
    public TextMesh status;
    public TextMesh activités;


    // Use this for initialization
    void Start () {
        numéro.text = "Fiche " + "1";
        age.text = "age : " + "25" + " ans";
        genre.text = "Femme";
        profession.text = "Travailleur";
        status.text = "mariée";
        activités.text = "j'aime le chocolat";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
