using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

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
		if (sexe == "Woman")
			GameObject.Find("Photo").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Portrait_2");
		else
			GameObject.Find("Photo").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Portrait_1");

		GameObject.Find("Emploi").GetComponent<Text>().text = emploi;
		GameObject.Find("Statut").GetComponent<Text>().text = statut;
		GameObject.Find("Hobbies").GetComponent<Text>().text = hobbies;
		GameObject.Find("Divers").GetComponent<Text>().text = divers;
		if (investigated == 3)
		{
			GameObject.Find("Religion").GetComponent<Text>().text = religion;
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
		if(info == "")
			GameObject.Find(archiveName).GetComponent<Text>().text = "";
		else
		{
			if (archiveName == "MedicalArchives")
			{
				GameObject.Find(archiveName).GetComponent<Text>().text = "Illness/Handicap : \n";
				GameObject.Find(archiveName).GetComponent<Text>().text += info;
			}
			else if(archiveName == "CriminalArchives")
			{
				GameObject.Find(archiveName).GetComponent<Text>().text = "Infraction : \n";
				GameObject.Find(archiveName).GetComponent<Text>().text += info;
			}
			else
			{
				string name = archiveName.Substring(0, archiveName.Length - 1);
				if(archiveName == "FinancialArchives1")
					GameObject.Find(name).GetComponent<Text>().text = "Debts to pay : \n";
				if (archiveName == "FinancialArchives2")
					GameObject.Find(name).GetComponent<Text>().text = "Tax to pay : \n";
				if (archiveName == "FinancialArchives3")
					GameObject.Find(name).GetComponent<Text>().text = "Account balance : \n";

				GameObject.Find(name).GetComponent<Text>().text += info;
			}
		}
	}
}
