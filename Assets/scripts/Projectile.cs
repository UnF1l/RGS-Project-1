using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float speed = 10f;			// Скорость снаряда
	[SerializeField] private float lifeTime = 3f;		// Время жизни снаряда в секундах
	[SerializeField] private Rigidbody2D rb;			// Снаряд

	private void Start()
	{
		Destroy(gameObject, lifeTime);					// Удаление снаряда по времени жизни
	}

	private void FixedUpdate()
	{
		rb.velocity = transform.up * speed;				// Движение снаряда
	}

	
}
