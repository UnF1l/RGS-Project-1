using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float speed = 10f;			
	[SerializeField] private float lifeTime = 3f;		
	[SerializeField] private Rigidbody2D rb;

	public string answer = "-1";
	private void Start()
	{
        answer = GameObject.Find("GameManager").GetComponent<gameManager>().value; ;
		Destroy(gameObject, lifeTime);					
	}
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Room") || collider.gameObject.CompareTag("Enemy"))
		{
			Destroy(gameObject);
		}
	}

	private void FixedUpdate()
	{
		rb.velocity = transform.up * speed;				
	}

	
}
