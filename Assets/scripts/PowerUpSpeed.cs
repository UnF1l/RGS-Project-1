using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
	private Rigidbody2D rb;

	[SerializeField] private float duration = 5f; 
	[SerializeField] private float speedInc = 100f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        GameObject whatHit = collision.gameObject;
		if (whatHit.CompareTag("Player"))
		{
			StartCoroutine(SpeedUp(collision));
		}
	}

	IEnumerator SpeedUp(Collider2D collision)
	{
		
		Debug.Log(("Speed up"));
		GetComponent<SpriteRenderer>().enabled = false;	
		GetComponent<CircleCollider2D>().enabled = false;	
		yield return new WaitForSeconds(duration);
		Debug.Log("Speed up gone");
		Destroy(gameObject);
	}

}
