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

    //Pickup
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float destroyTime;


    // When the enemy collides with another object
    void OnCollisionEnter(Collision col)
    {
        //If the player hit an object with the bulltet tag
        if (col.gameObject.tag == "Bullet")
        {
            health -= 10f;
        }

        // If the enemy makes it to the end (hits end wall), it will destroy
        if (col.gameObject.name == "End of Pathway")
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        EnemyLife();
    }

    // Moves the object to the object that is set as the vairable of 'pathEnd'
    void EnemyMove()
    {
        agent.SetDestination(pathEnd.transform.position);
    }

    // Handles the enemies health and what happens upon hitting 0 health
    void EnemyLife()
    {
        //If health is 0
        if (health <= 0)
        {
            ItemDrop();
            Destroy(gameObject);            
        }
    }

    // Handles what item dropsand what it does for the player
    void ItemDrop()
    {
        Rigidbody ElectricityDrop;
        ElectricityDrop = Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
    }
}
