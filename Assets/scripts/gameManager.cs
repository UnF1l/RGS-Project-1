using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Button[] arrBtn = new Button[10];
    //public Enemy enemy;
    public int numClicked = -1;
    public string value = "0";
    void Start()
    {
        Generator Gen = GetComponent<Generator>();
        SetArrBtn();
        Gen.Generate();
        enemyBehavior enemy = GameObject.Find("enemy").GetComponent<enemyBehavior>();
        enemy.Set(Gen.str, Gen.ans);
    }

    public void ChooseAnswer(string num)
    {
        value = arrBtn[int.Parse(num)].GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void ChangeAnswer(int id, string text)
    {
        arrBtn[id].GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
    void SetArrBtn()
    {
        arrBtn[0] = GameObject.Find("firstAnswerButton").GetComponent<Button>();
        arrBtn[1] = GameObject.Find("Answer2").GetComponent<Button>();
        arrBtn[2] = GameObject.Find("Answer3").GetComponent<Button>();
        arrBtn[3] = GameObject.Find("Answer4").GetComponent<Button>();
        arrBtn[4] = GameObject.Find("Answer5").GetComponent<Button>();
    }
}
