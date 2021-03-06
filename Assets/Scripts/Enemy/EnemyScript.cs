﻿using UnityEngine;
using System.Collections;


public class EnemyScript : MonoBehaviour
{
    //Movement
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject pathEnd;

    //Health
    
    public float health = 100f;

    //Pickup
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float destroyTime;

    //Enemy Spawn
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;

    public GameObject soundController;

    //Enemy Spawn Stop
    public float EnemyAmount;

    public GameObject explosion;

    public GameObject eventM;


    // When the enemy collides with another object
    void OnCollisionEnter(Collision col)
    {
        // If the enemy makes it to the end (hits end wall), it will destroy
        if (col.gameObject.name == "End of Pathway")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //If the player hit an object with the bulltet tag
        if (col.gameObject.tag == "Bullet")
        {
            health -= 10f;
        }
    }

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //Enemy Spawn
        InvokeRepeating("Spawn", spawnTime, spawnTime);

        //Movement
        pathEnd = GameObject.FindWithTag("PathEnd");

        soundController = GameObject.FindWithTag("SoundController");
        eventM = GameObject.FindWithTag("EventManager");
        UpdateEnemies();
        //Enemy Start
        Spawn();

        




    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        EnemyLife();
        EnemySpawnStop();
        Debug.Log(health);

        
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
            soundController.GetComponent<SoundController>().explosionPlay();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            explosion.GetComponent<ParticleSystem>().Play();
        }
    }

    // Handles what item dropsand what it does for the player
    void ItemDrop()
    {
        Rigidbody ElectricityDrop;
        ElectricityDrop = Instantiate(coinPrefab, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
    }

    //Determines the spawn time and location of enemies.
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    void EnemySpawnStop()
    {
        float EnemyAmount = (GameObject.FindGameObjectsWithTag("Enemy").Length);
        if (EnemyAmount >= 10)
        {
            Destroy(GameObject.FindWithTag("Spawn"));
        }
    }

    void UpdateEnemies()
    {
        Debug.Log("i ran but did nothing");
        if (eventM.GetComponent<EnemySpawnWave>().eventCounter == 2)
        {
            health += 70;
        }
        if (eventM.GetComponent<EnemySpawnWave>().eventCounter == 3)
        {
            health += 170;
        }
    }
}
