using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFreeze : MonoBehaviour
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
			StartCoroutine(freeze());
		}
	}

	IEnumerator freeze()
	{
		Debug.Log("Freeze");
		for (int i = 0; i < Data.enemies.Count; i++) { Data.enemies[i].speed /= multiplier; }
        GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<CircleCollider2D>().enabled = false;
		yield return new WaitForSeconds(duration);
        for (int i = 0; i < Data.enemies.Count; i++) { Data.enemies[i].speed *= multiplier; }
        Debug.Log("Freeze gone");
		Destroy(gameObject);
	}
}
