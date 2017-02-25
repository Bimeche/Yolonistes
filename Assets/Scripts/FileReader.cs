using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour {
    public List<CharacterInfos> listCharacters = new List<CharacterInfos>();

    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " "; // assigned to allow first line to be read below

    void Start()
    {
        theSourceFile = new FileInfo("Fiches.txt");
        reader = theSourceFile.OpenText();

        text = reader.ReadLine();

        while (text != null)
        {
            CreateCharacter();
            text = reader.ReadLine();
        }

        foreach (CharacterInfos i in listCharacters)
        {

            Debug.Log(i.guilty + " " + i.number + " " + i.age + " " + i.genre + " " + i.emploi + " " + i.hobbies + " " + i.notable + " "
                + i.finance.dette + " " + i.finance.impots + " " + i.finance.solde
                + " " + i.crime.atteintePersonnelle + " " + i.crime.atteinteGouvernement + " "+ i.crime.atteinteMaterielle + " "
                + i.medical.psychologique + " " + i.medical.maladie + " " +   i.medical.hospitalisation + " "
                + i.politique.religion + " " + i.politique.engagement + "\n");
        }
    }

    public void CreateCharacter()
    {

        bool guilt = false;
        string num;
        int a;
        string gen;
        string emp;
        string mar;
        string hob;
        string not = "";

        string d = "";
        string imp = "";
        string s = "";

        string p = "";
        string g = "";
        string m = "";

        string psy = "";
        string mal = "";
        string hos = "";

        string rel = " ";
        string eng = "";

        if (text.Equals("g"))
        {
            guilt = true;
        }
        text = reader.ReadLine();
        num = text;
        text = reader.ReadLine();
        int.TryParse(text, out a);
        text = reader.ReadLine();
        gen = text;
        text = reader.ReadLine();
        emp = text;
        text = reader.ReadLine();
        mar = text;
        text = reader.ReadLine();
        hob = text;
        text = reader.ReadLine();
        if(!text.Equals("0"))
        {
            not = text;
        }
        text = reader.ReadLine();

        if (!text.Equals("0"))
        {
            d = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("0"))
        {
            imp = text;
        }
        text = reader.ReadLine(); if (!text.Equals("0"))
        {
            s = text;
        }
        text = reader.ReadLine();

        if (!text.Equals("0"))
        {
            p = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("0"))
        {
            g = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("0"))
        {
            m = text;
        }
        text = reader.ReadLine();

        if (!text.Equals("0"))
        {
            psy = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("0"))
        {
            mal = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("0"))
        {
            hos = text;
        }
        text = reader.ReadLine();

        if (!text.Equals("0"))
        {
            rel = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("0"))
        {
            eng = text;
        }

        listCharacters.Add(new CharacterInfos(guilt, num, a, gen, emp, mar, hob, not, d, imp, s, p, g, m, psy, mal, hos, rel, eng));
    }

    void Update()
    {

    }
}
