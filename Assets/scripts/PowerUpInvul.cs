using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvul : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float duration = 10f; // Длительность неуязвимости
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        GameObject whatHit = collision.gameObject;
		if (whatHit.CompareTag("Player"))
		{
			StartCoroutine(invulnerability(collision));
		}
	}

    IEnumerator invulnerability(Collider2D collision)
	{
		// Установить игроку статус неуязвимости
		// (Код)
		Debug.Log("Invulnerability");
		GetComponent<SpriteRenderer>().enabled = false;     // Отключение видимости
		GetComponent<CircleCollider2D>().enabled = false;   // Отключение колайдера
		yield return new WaitForSeconds(duration);
		// Убрать у игрока статус неуязвимости
		// (Код)
		Debug.Log("Invulnerability gone");
		Destroy(gameObject);
	}
}
