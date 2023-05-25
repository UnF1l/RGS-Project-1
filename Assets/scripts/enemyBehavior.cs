using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enemyBehavior : MonoBehaviour
{
    public float speed = 2.5f;
    public string question = "0";
    public GameObject player;
    public string answer = "-1";
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "projectile" && other.gameObject.GetComponent<Projectile>().answer == answer) 
        {
            Data.enemies.Remove(this);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            Data.PlayerHP--;
            if (Data.PlayerHP <= 0) Destroy(player);
        }
    }

    private void MoveEnemy()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
        }
        else GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void Set(string question, string answer)
    {
        this.question = question;
        this.answer = answer;
        GetComponentInChildren<TextMeshProUGUI>().text = question;
    }
}
