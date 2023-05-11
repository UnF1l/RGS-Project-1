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
        enemyBehavior[] test = new enemyBehavior[1] { GameObject.Find("enemy").GetComponent<enemyBehavior>() };
        EnemyGen(test);
    }
    void EnemyGen(enemyBehavior[] enemies)
    {
        string[] ans = new string[enemies.Length];
        for(int i = 0; i < enemies.Length; i++) {
            Gen.Generate();
            enemies[i].Set(Gen.str, Gen.ans);
            ans[i] = Gen.ans;
        }
        answers.fill(ans);
    }
}
