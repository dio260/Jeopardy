using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TestFolderCreationOnBuild : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!Directory.Exists(Application.dataPath + "/Game Decks"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Game Decks");
            Debug.LogAssertion("Folder created at " + Application.dataPath);

        }
        // else
        // {
        //     Debug.LogAssertion("Folder already exists in " + Path.GetDirectoryName(Application.dataPath + "/Game Decks"));
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
