using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    public GameObject soundController;

    private Transform target;
    private EnemyHealth targetEnemy;
    public float range = 20f;

    public string enemyTag = "Enemy";

    public Transform Rotator;
    public float turnSpeed = 10f;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPreFab;
    public Transform firePoint;

    public bool uselaser = false;
    public LineRenderer lineRenderer;
    public bool active = false;

    public int damageOverTime = 0;

    public float slowPercent = 0.5f;

	void Start ()
    {
        //UpdateTarget is called 2X a second
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    //Find the nearest target.
    void UpdateTarget ()
    {
        //Find gameObject with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        //Store the shortest distance to found enemy
        float shortestDistance = Mathf.Infinity;
        //Store nearest Enemy
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            //Get disntance to enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //is the distance shorter than the distance found before?
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //if we found an enemy and the shortest distance is in our range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            //Then target that enemy
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyHealth>();
        }
        else
        {
            //if they leave range..then stop targeting them
            target = null;
        }
    }

	
	void Update ()
    {
        if(!active)
        {
            return;
        }
        //if no traget is present... dont do anything
        if (target == null)
        {
            if (uselaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }
            return;
        }

        LockOnTarget();
        if(uselaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

	}

    void LockOnTarget ()
    {
        //Get a vector that points in the direction of the enemy
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        //Smoothly rotate to new enemy
        Vector3 rotation = Quaternion.Lerp(Rotator.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Rotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser ()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPercent);

        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;
        
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet> ();

        if (bullet != null)
            bullet.Find(target);

        soundController.GetComponent<SoundController>().shootPlay();
    }

    void OnDrawGizmosSelected ()
    {
        //Range is now colored red
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
