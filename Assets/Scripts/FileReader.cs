using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour {

    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " "; // assigned to allow first line to be read below

    void Start()
    {
        theSourceFile = new FileInfo("Test.txt");
        reader = theSourceFile.OpenText();
    }

    void Update()
    {
        if (text != null)
        {
            text = reader.ReadLine();
            //Console.WriteLine(text);
            print(text);
        }
    }
}
