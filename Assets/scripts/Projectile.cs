using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float speed = 10f;			// �������� �������
	[SerializeField] private float lifeTime = 3f;		// ����� ����� ������� � ��������
	[SerializeField] private Rigidbody2D rb;			// ������

	private void Start()
	{
		Destroy(gameObject, lifeTime);					// �������� ������� �� ������� �����
	}

	private void FixedUpdate()
	{
		rb.velocity = transform.up * speed;				// �������� �������
	}

	
}
