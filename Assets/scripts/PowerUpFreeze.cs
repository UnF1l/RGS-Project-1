using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFreeze : MonoBehaviour
{
	private Rigidbody2D rb;

	[SerializeField] private float duration = 5f; // ������������ ���������� ������
	[SerializeField] private float freezeSpeed = 100f; // �������� ������ ����� ����������
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
		// ��������� �������� ������������ ������ �� freezeSpeed
		// (���)
		Debug.Log("Freeze");
		GetComponent<SpriteRenderer>().enabled = false;     // ���������� ���������
		GetComponent<CircleCollider2D>().enabled = false;   // ���������� ���������
		yield return new WaitForSeconds(duration);
		// ������� ����������� �������� ������������ ������
		// (���)
		Debug.Log("Freeze gone");
		Destroy(gameObject);
	}
}
