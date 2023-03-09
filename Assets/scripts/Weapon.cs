using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector2 mousePos;                                   // ������� ��������� �������

    [SerializeField] private GameObject projectilePrefab;       // ������ �������
    [SerializeField] private Transform firingPoint;             // ����� ��������(����� ��� ���������� ������)

	void Update()
    {
        // ���������� ��������� �������
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ������ ���� �������� ������
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        // ������� ������ �� ����������� ����
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // �������
		if (Input.GetMouseButtonDown(0))
		{
            shoot();
		}
    }

    // �������� �������
    private void shoot()
	{
        Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
	}
}
