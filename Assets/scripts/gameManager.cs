using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Button[] arrBtn = new Button[10];
    //public Enemy enemy;
    public string value = "0";
    void Start()
    {
        Generator Gen = GetComponent<Generator>();
        Gen.Generate();
        enemyBehavior enemy = GameObject.Find("enemy").GetComponent<enemyBehavior>();
        enemy.Set(Gen.str, Gen.ans);
        Answers answers = GameObject.Find("Answers").GetComponent<Answers>();
        answers.fill(Convert.ToInt32(Gen.ans));
    }
}
