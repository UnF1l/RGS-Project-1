using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvul : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float duration = 10f; // ������������ ������������
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
		// ���������� ������ ������ ������������
		// (���)
		Debug.Log("Invulnerability");
		GetComponent<SpriteRenderer>().enabled = false;     // ���������� ���������
		GetComponent<CircleCollider2D>().enabled = false;   // ���������� ���������
		yield return new WaitForSeconds(duration);
		// ������ � ������ ������ ������������
		// (���)
		Debug.Log("Invulnerability gone");
		Destroy(gameObject);
	}
}
