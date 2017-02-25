using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour {
    public List<CharacterInfo> listCharacters = new List<CharacterInfo>();

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

        foreach(CharacterInfo i in listCharacters)
        {
            Debug.Log(i.guilty + " " + i.number + " " + i.age + " " + i.genre + " " + i.emploi + " " + i.hobbies + " " + i.notable + " " + i.finance.dette + " " + i.finance.infraction
                + " " + i.crime.crime + " " + i.medical.psychologique + " " + i.medical.condition + " " + i.politique.religion + " " + i.politique.engagement +"\n");
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
        string inf = "";
        string c = "";
        string psy = "";
        string con = "";
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
            inf = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("0"))

        {
            c = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("0"))
        {
            psy = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("0"))
        {
            con = text;
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

        listCharacters.Add(new CharacterInfo(guilt, num, a, gen, emp, mar, hob, not, d, inf, c, psy, con, rel, eng));
    }

    void Update()
    {

    }
}
