using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class CSVToJeopardy : MonoBehaviour
{
    string deckPath;
    public string fileName;

    public GameObject playMenu, categoryParent;
    public GameObject categoryTemplate, questionTemplate;
    public CanvasGroup gameCanvas;
    // Start is called before the first frame update
    void Start()
    {
        deckPath = Application.dataPath + "/Game Decks/";
        gameCanvas.alpha = 0;
    }


    public void setFileName(string name)
    {
        fileName = name;
    }

    public void GenerateJeopardy()
    {
        playMenu.SetActive(false);
        gameCanvas.alpha = 1;
        using (StreamReader sr = File.OpenText(deckPath + fileName))
        {
            string s = "";
            string[] splitList = sr.ReadToEnd().Split('\n');
            string[] questionValues = splitList[0].Split(',');
            for (int categoryNum = 1; categoryNum < splitList.Length; categoryNum++)
            {
                string[] categoryList = splitList[categoryNum].Split(',');
                GameObject category = Instantiate(categoryTemplate, categoryParent.transform);
                Debug.Log(categoryList[0]);
                category.GetComponentInChildren<TMP_Text>().text = categoryList[0];
                category.SetActive(true);
                for (int questionNum = 1; questionNum < categoryList.Length; questionNum += 2)
                {

                    GameObject question = Instantiate(questionTemplate, category.transform);
                    question.GetComponent<JeopardyTile>().value.text = questionValues[questionNum];
                    question.GetComponent<JeopardyTile>().question = categoryList[questionNum];
                    question.GetComponent<JeopardyTile>().answer = categoryList[questionNum + 1];
                    question.SetActive(true);

                }

            }

        }
    }
}
