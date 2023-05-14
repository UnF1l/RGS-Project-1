using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
	private Rigidbody2D rb;

	[SerializeField] private float duration = 5f; 
	[SerializeField] private float multiplier = 1.5f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        GameObject whatHit = collision.gameObject;
		if (whatHit.CompareTag("Player"))
		{
			StartCoroutine(SpeedUp(whatHit));
		}
	}

	IEnumerator SpeedUp(GameObject player)
	{
		
		Debug.Log(("Speed up"));
		GetComponent<SpriteRenderer>().enabled = false;	
		GetComponent<CircleCollider2D>().enabled = false;
		player.GetComponent<PlayerMovement>().moveSpeed *= multiplier;
        player.GetComponent<PlayerMovement>().dashSpeed *= multiplier;
        yield return new WaitForSeconds(duration);
        player.GetComponent<PlayerMovement>().moveSpeed /= multiplier;
        player.GetComponent<PlayerMovement>().dashSpeed /= multiplier;
        Debug.Log("Speed up gone");
		Destroy(gameObject);
	}

}
