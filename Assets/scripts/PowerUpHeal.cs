using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject whatHit = collision.gameObject;
		if (whatHit.CompareTag("Player"))
		{
			// Присвоить переменной ХП игрока максимальное значение
			Debug.Log("Player heal");
			Destroy(gameObject);
		}
	}
}
