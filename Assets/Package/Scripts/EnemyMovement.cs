using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyHealth))]

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private EnemyHealth enemy;
    private int wavepointIndex = 0;

    void Start ()
    {
        enemy = GetComponent<EnemyHealth>();
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <=0.2f)
        {
            GetNextWaypoint();

        }
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length -1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}

