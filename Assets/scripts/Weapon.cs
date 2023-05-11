using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector2 mousePos;

    public AudioClip audioClip;
    private AudioSource audioSource;

    [SerializeField] private GameObject projectilePrefab;     
    [SerializeField] private Transform firingPoint;
    private float angle;
    private bool canShoot = true;
    public float delay;

    IEnumerator wait(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        canShoot = true;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	void Update()
    {
       
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
      

		if ((Input.GetMouseButtonDown(0))&&(canShoot))
		{
            shoot();
            canShoot = false;
            StartCoroutine(wait(delay));
		}
    }
    
    private void shoot()
	{
        audioSource.PlayOneShot(audioClip);
        Instantiate(projectilePrefab, firingPoint.position, Quaternion.Euler(0, 0, angle));
	}
}
