using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoFinancier
{
    public string dette;
    public string impots;
    public string solde;

    public InfoFinancier(string d, string imp, string s)
    {
        dette = d;
        impots = imp;
        solde = s;
    }
}

public class InfoCriminel
{
    public string atteintePersonnelle;
    public string atteinteGouvernement;
    public string atteinteMaterielle;

    public InfoCriminel(string p, string g, string m)
    {
        atteintePersonnelle = p;
        atteinteGouvernement = g;
        atteinteMaterielle = m;
    }
}

public class InfoMedical
{
    public string psychologique;
    public string maladie;
    public string hospitalisation;

    public InfoMedical(string psy, string mal, string hos)
    {
        psychologique = psy;
        maladie = mal;
        hospitalisation = hos;
    }
}

public class InfoPolitique
{
    public string religion;
    public string engagement;

    public InfoPolitique(string rel, string eng)
    {
        religion = rel;
        engagement = eng;
    }
}

public class CharacterInfos
{
    public int statut;  // -1 New, 1 Returning selected as Non Guilty , 2 Investigated selected as To investigate , 3 Completed 
    public int outcome; // -1 No choice yet, 1 GUilty, 2 Non Guilty, 3 ToInvestigate

    public bool guilty;
    public string number;
    public int age;
    public string genre;
    public string emploi;
    public string marital;
    public string hobbies;
    public string notable;

    public InfoCriminel crime;
    public InfoFinancier finance;
    public InfoMedical medical;
    public InfoPolitique politique;

    public CharacterInfos(bool guilt, string num, int a, string gen, string emp, string mar, string hob, string not, 
        string d, string imp, string s, 
        string p, string g, string m, 
        string psy, string mal, string hos, 
        string rel, string eng)
    {
        statut = -1;//initializé à -1 pour savoir que c'est pas la valeur finale
        outcome = -1;

        guilty = guilt;
        number = num;
        age = a;
        genre = gen;
        emploi = emp;
        marital = mar;
        hobbies = hob;
        notable = not;

        crime = new InfoCriminel(p, g, m);
        finance = new InfoFinancier(d, imp, s);
        medical = new InfoMedical(psy, mal, hos);
        politique = new InfoPolitique(rel, eng);
    }

}

public class CharacterFile : MonoBehaviour {
    

  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
