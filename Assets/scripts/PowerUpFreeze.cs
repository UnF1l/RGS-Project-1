using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFreeze : MonoBehaviour
{
	private Rigidbody2D rb;

	[SerializeField] private float duration = 5f; // Длительность замедления врагов
	[SerializeField] private float freezeSpeed = 100f; // Скорость врагов после замедления
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject whatHit = collision.gameObject;
		if (whatHit.CompareTag("Player"))
		{
			StartCoroutine(freeze(collision));
		}
	}

	IEnumerator freeze(Collider2D collision)
	{
		// Уменьшить скорость передвижения врагам до freezeSpeed
		// (Код)
		Debug.Log("Freeze");
		GetComponent<SpriteRenderer>().enabled = false;     // Отключение видимости
		GetComponent<CircleCollider2D>().enabled = false;   // Отключение колайдера
		yield return new WaitForSeconds(duration);
		// Вернуть стандартную скорость перелвидения врагам
		// (Код)
		Debug.Log("Freeze gone");
		Destroy(gameObject);
	}
}
