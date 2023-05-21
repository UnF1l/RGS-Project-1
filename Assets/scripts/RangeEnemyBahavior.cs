using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyBahavior : MonoBehaviour
{
    private Transform player;
    public GameObject projectile;
    public GameObject firingPoint;
    public float shootingRange = 300f;
    public float fireRate = 2f;
    private float nextFireTime;

    public string question = "0";
    public string answer = "-1";
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "projectile" && other.gameObject.GetComponent<Projectile>().answer == answer)
        {
            Data.enemies.Remove(this);
            Destroy(gameObject);
        }
    }*/
   /* public void Set(string question, string answer)
    {
        this.question = question;
        this.answer = answer;
        GetComponentInChildren<TextMeshProUGUI>().text = question;
    }
*/
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(player.position, transform.position);
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
