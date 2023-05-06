using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class JeopardyTile : MonoBehaviour
{
    public GameObject panelHolder;
    public TMP_Text value;
    public string question, answer;
    public Button questionButton;
    // Start is called before the first frame update
    void Start()
    {
        questionButton = GetComponent<Button>();
        questionButton.onClick.AddListener(MoveToQuestion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveToQuestion()
    {
        panelHolder.transform.Find("QuestionText").GetComponent<TMP_Text>().text = question;
        panelHolder.SetActive(true);
        panelHolder.GetComponent<Button>().onClick.AddListener(MoveToAnswer);
    }

    void MoveToAnswer()
    {
        panelHolder.GetComponent<Button>().onClick.RemoveListener(MoveToAnswer);
        panelHolder.transform.Find("QuestionText").GetComponent<TMP_Text>().text = answer;
        panelHolder.GetComponent<Button>().onClick.AddListener(ClosePanel);
    }

    void ClosePanel()
    {
        questionButton.enabled = false;
        value.color = Color.green;
        panelHolder.GetComponent<Button>().onClick.RemoveAllListeners();
        panelHolder.SetActive(false);
    }
}
