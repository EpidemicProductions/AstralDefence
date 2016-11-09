using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;

    public int damage = 25;

    public void Find (Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if Enemy leaves range while a shot is fired
	if (target == null)
        {
            //then destroy the bullet object
            Destroy(gameObject);
            return;
        }

        //Find the direction for the bullet to travel
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        //rotate the missile
       // transform.LookAt(target);
	}

    void HitTarget ()
    {
        // THIS DESTROYS THE ENEMY INSTANTLY
        //Destroy(target.gameObject);
        //This destroys the bullet once it connects with enemy
        Destroy(gameObject);
    }
}
