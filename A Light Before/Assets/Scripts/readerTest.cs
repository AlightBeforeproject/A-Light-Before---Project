using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class readerTest : MonoBehaviour
{
    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text /*= " "*/; // assigned to allow first line to be read below
    protected char[] delimiter = { ':' };
    string[] fields = null;

    void Start()
    {
        theSourceFile = new FileInfo("Assets\\Resources\\map.txt");
        reader = theSourceFile.OpenText();
    }

    void Update()
    {
        text = reader.ReadLine();
        if (text != null)
        {
            
            fields = text.Split(delimiter);
            //Debug.Log(fields[0]);
            print(fields[0]);
        }
    }
}
