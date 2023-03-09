using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector2 mousePos;                                   // Текущее положение курсора

    [SerializeField] private GameObject projectilePrefab;       // Префаб снаряда
    [SerializeField] private Transform firingPoint;             // Точка выстрела(Место где появляется снаряд)

	void Update()
    {
        // Считывание положения курсора
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Расчет угла поворота оружия
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        // Поворот оружия на расчитанный угол
        transform.localRotation = Quaternion.Euler(0, 0, angle);

        // Выстрел
		if (Input.GetMouseButtonDown(0))
		{
            shoot();
		}
    }

    // Создание снаряда
    private void shoot()
	{
        Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
	}
}
