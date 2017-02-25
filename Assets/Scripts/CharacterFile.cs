using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoFinancier
{
    public string dette;
    public string infraction;

    public InfoFinancier(string d, string inf)
    {
        dette = d;
        infraction = inf;
    }
}

public class InfoCriminel
{
    public string crime;

    public InfoCriminel(string c)
    {
        crime = c;
    }
}

public class InfoMedical
{
    public string psychologique;
    public string condition;

    public InfoMedical(string psy, string con)
    {
        psychologique = psy;
        condition = con;
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

public class CharacterInfo
{
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

    public CharacterInfo(bool g, string num, int a, string gen, string emp, string hob, string mar, string not, string d, string inf, string c, string psy, string con, string rel, string eng)
    {
        guilty = g;
        number = num;
        age = a;
        genre = gen;
        emploi = emp;
        marital = mar;
        hobbies = hob;
        notable = not;

        crime = new InfoCriminel(c);
        finance = new InfoFinancier(d, inf);
        medical = new InfoMedical(psy, con);
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
