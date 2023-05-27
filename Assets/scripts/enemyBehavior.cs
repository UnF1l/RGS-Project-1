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
    bool canDamage = true;
    public float delay;
    public Animator animator;
    IEnumerator wait(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        canDamage = true;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            if(canDamage)
            {
                //animator.SetBool("isAttack", true);
                Data.PlayerHP--;
                canDamage = false;
                StartCoroutine(wait(delay));
                //animator.SetBool("isAttack", false);
            }            
        }
    }

    public virtual void MoveEnemy()
    {

        if (player != null)
        {
            if (player.transform.position.x > transform.position.x) GetComponent<SpriteRenderer>().flipX = false;
            else GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("isMove", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            animator.SetBool("isMove", false);
        }
        
    }

    public void Set(string question, string answer)
    {
        this.question = question;
        this.answer = answer;
        GetComponentInChildren<TextMeshProUGUI>().text = question;
    }
}
