using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class ShowCSVList : MonoBehaviour
{
    string deckPath = "";
    RectTransform rt;
    public GameObject fileTemplate;
    public RectTransform content;
    float addHeight;
    public CSVToJeopardy jepGen;
    public Button play;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        addHeight = fileTemplate.GetComponent<RectTransform>().rect.height;
        Debug.Log(addHeight);
        deckPath = Application.dataPath + "/Game Decks";
        play.onClick.AddListener(jepGen.GenerateJeopardy);
        GetCSVs();
    }

    // Update is called once per frame
    void GetCSVs()
    {
        if(content.transform.childCount != 0)
        {
            foreach(Transform child in content.transform)
            {
                Destroy(child.gameObject);
            }
        }

        DirectoryInfo dir = new DirectoryInfo(deckPath);
        FileInfo[] csvList = dir.GetFiles("*.csv");
        foreach(FileInfo file in csvList)
        {
            // content.sizeDelta = new Vector2(content.rect.width, content.rect.height + addHeight);
            // Debug.Log(file.Name);
            GameObject newFile =  Instantiate(fileTemplate, content);
            newFile.name = file.Name;
            newFile.transform.Find("FileName").GetComponent<TMP_Text>().text = file.Name.Substring(0, file.Name.Length - 4);
            newFile.SetActive(true);
            newFile.transform.GetComponentInChildren<Button>().onClick.AddListener(() => jepGen.setFileName(file.Name));
        }
    }
}
