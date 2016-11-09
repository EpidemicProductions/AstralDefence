using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    //Movement
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject pathEnd;

    //Health
    [SerializeField]
    private float health = 100f;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    //Moves the object to the object with the tag 'pathEnd'.
    void EnemyMove()
    {
        agent.SetDestination(pathEnd.transform.position);
    }
}
