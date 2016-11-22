using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int health = 100;
	// Use this for initialization
	void Start () {
	
	}
	
    public void TakeDamage (int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
