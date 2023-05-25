using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyBahavior : enemyBehavior
{
    public GameObject projectile;
    public GameObject firingPoint;
    public float shootingRange = 300f;
    public float fireRate = 2f;
    private float nextFireTime;
    

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
            if (distanceToPlayer <= shootingRange && nextFireTime < Time.time)
            {
                Instantiate(projectile, firingPoint.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
	}
}
