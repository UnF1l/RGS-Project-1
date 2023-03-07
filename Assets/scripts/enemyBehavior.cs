using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
public class enemyBehavior : MonoBehaviour
{
    public const float speed = 2.5f;
    public string question = "0";
    public GameObject player;
    public string answer = "-1";

    private void Start()
    {

    }
    private void FixedUpdate()
    {
        MoveEnemy();
    }


    private void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
    }

    public void Set(string question, string answer)
    {
        this.question = question;
        this.answer = answer;
        GetComponentInChildren<TextMeshProUGUI>().text = question;
    }

    public void GetAnswer(string _answer)
    {
        if (_answer == answer)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseUp()
    {
        string _answer = GameObject.Find("GameManager").GetComponent<gameManager>().value;
        GetAnswer(_answer);
    }
}
