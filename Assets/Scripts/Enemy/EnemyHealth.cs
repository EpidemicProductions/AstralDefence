using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    

    public float health = 100;

    public float startSpeed = 10f;
    public float speed;


    void Strat ()
    {
        speed = startSpeed;
        
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Death();
        }
    }

    public void Slow (float percent)
    {
        speed = startSpeed * (1f - percent);
    }

    void Death()
    {
        Destroy(gameObject);
        
    }

  
}
