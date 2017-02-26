using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class FillSheet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FillMainSheet(string num, string age, string sexe, string emploi, string statut, string hobbies, string divers, string religion, string politique, int investigated)
	{
		GameObject.Find("Numero").GetComponent<Text>().text = num;
		GameObject.Find("Age").GetComponent<Text>().text = age;
		GameObject.Find("Sexe").GetComponent<Text>().text = sexe;
		if(sexe == "Woman")
			GameObject.Find("Photo").GetComponent<Image>().sprite= AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Portrait_2.png");
		else
			GameObject.Find("Photo").GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Portrait_1.png");

		GameObject.Find("Emploi").GetComponent<Text>().text = emploi;
		GameObject.Find("Statut").GetComponent<Text>().text = statut;
		GameObject.Find("Hobbies").GetComponent<Text>().text = hobbies;
		GameObject.Find("Divers").GetComponent<Text>().text = divers;
		if (investigated == 2)
		{
			GameObject.Find("Religion").GetComponent<Text>().text = num;
			GameObject.Find("Politique").GetComponent<Text>().text = politique;
		}
		else if(investigated == 10)
		{

			GameObject.Find("Religion").GetComponent<Text>().text = "";
			GameObject.Find("Politique").GetComponent<Text>().text = "";
		}
		else{
			GameObject.Find("Religion").GetComponent<Text>().text = "?";
			GameObject.Find("Politique").GetComponent<Text>().text = "?";
		}
	}

	public void FillInfoSheets(string archiveName, string info)
	{
		GameObject.Find(archiveName).GetComponent<Text>().text = info;
	}
}
