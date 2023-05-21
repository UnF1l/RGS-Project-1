using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    GameObject target;
    public float speed = 120f;
    public float lifeTime = 3f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Room"))
        {
            Destroy(gameObject);
        }
		if (collider.gameObject.CompareTag("Player"))
		{
            Data.PlayerHP--;
            Destroy(gameObject);
            Debug.Log(Data.PlayerHP);
            if (Data.PlayerHP <= 0) Destroy(collider.gameObject);

        }
    }
}
