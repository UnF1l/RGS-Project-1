using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public List<GameObject> HPs;
    public string value = "0";
    Generator Gen;
    Answers answers;
    public GameObject player;
    public GameObject canvas;
    void Start()
    {
        Gen = GetComponent<Generator>();
        answers = GameObject.Find("Answers").GetComponent<Answers>();
        Data.enemies.Add(GameObject.Find("enemy").GetComponent<enemyBehavior>());
        Data.enemies.Add(GameObject.Find("enemy1").GetComponent<enemyBehavior>());
        Data.enemies.Add(GameObject.Find("RangeEnemy").GetComponent<enemyBehavior>());
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
    void death()
    {
        canvas.GetComponent<EndScreenButtonManager>().EndGame();
    }
    public void UpdateHP()
    {
        foreach(GameObject hp in HPs)
        {
            if (Data.PlayerHP >= Convert.ToInt32(hp.name))
            {
                hp.SetActive(true);
            }
            else hp.SetActive(false);
        }
        if (Data.PlayerHP <= 0)
        {
            player.GetComponent<Animator>().SetBool("isAlive", false);
            Invoke("death", 0.5f);
        }
    }
}
