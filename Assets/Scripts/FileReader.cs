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
        theSourceFile = new FileInfo("Assets/Fiches.txt");
        reader = theSourceFile.OpenText();

        text = reader.ReadLine();

        while (text != null)
        {
            CreateCharacter();
            text = reader.ReadLine();
        }
        
        
    }

  void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
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
        if(!text.Equals("!"))
        {
            not = text;
        }
        text = reader.ReadLine();

        if (!text.Equals("!"))
        {
            d = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("!"))
        {
            imp = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("!"))
        {
            s = text;
        }
        text = reader.ReadLine();

        if (!text.Equals("!"))
        {
            p = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("!"))
        {
            g = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("!"))
        {
            m = text;
        }
        text = reader.ReadLine();

        if (!text.Equals("!"))
        {
            psy = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("!"))
        {
            mal = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("!"))
        {
            hos = text;
        }
        text = reader.ReadLine();

        if (!text.Equals("!"))
        {
            rel = text;
        }
        text = reader.ReadLine();
        if (!text.Equals("!"))
        {
            eng = text;
        }

        listCharacters.Add(new CharacterInfos(guilt, num, a, gen, emp, mar, hob, not, d, imp, s, p, g, m, psy, mal, hos, rel, eng));
    }

    void Update()
    {

    }
}
