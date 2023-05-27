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
        MoveEnemy();
    }

    public override void MoveEnemy()
    {
        if (player != null)
        {
            animator.SetBool("isMove", true);
            float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
            if (player.transform.position.x > transform.position.x) GetComponentInChildren<SpriteRenderer>().flipX = false;
            else GetComponentInChildren<SpriteRenderer>().flipX = true;
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
