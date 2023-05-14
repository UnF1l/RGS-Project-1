using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Button[] arrBtn = new Button[10];
    public string value = "0";
    Generator Gen;
    Answers answers;
    void Start()
    {
        Gen = GetComponent<Generator>();
        answers = GameObject.Find("Answers").GetComponent<Answers>();
        Data.enemies.Add(GameObject.Find("enemy").GetComponent<enemyBehavior>());
        Data.enemies.Add(GameObject.Find("enemy1").GetComponent<enemyBehavior>());
        EnemyGen();
    }
    void EnemyGen()
    {
        string[] ans = new string[Data.enemies.Count];
        for(int i = 0; i < Data.enemies.Count; i++) {
            Gen.Generate();
            Data.enemies[i].Set(Gen.str, Gen.ans);
            ans[i] = Gen.ans;
        }
        answers.fill(ans);
    }
}
