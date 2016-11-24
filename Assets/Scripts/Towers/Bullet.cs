using UnityEngine;

public class Bullet : MonoBehaviour
{
    private AudioSource audioSource;
    private Transform target;

    public float speed = 70f;

    public int damage = 25;
    public float aoeRadius = 0f;


    public void Find (Transform _target)
    {
        target = _target;
    }
	
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
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

        if (aoeRadius > 0f)
        {
            Explode(); 
        }
        else
        {
            Damage(target);
        }
        //This destroys the bullet once it connects with enemy
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, aoeRadius);
        foreach (Collider collider in colliders)
        {
            if (GetComponent<Collider>().tag == "Enemy")
            {
                Damage(GetComponent<Collider>().transform);
            }
        }
    }

    void Damage (Transform enemy)
    {
        EnemyHealth e = enemy.GetComponent<EnemyHealth>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
        //Destroy(enemy.gameObject);
    }

    void OnDrawGizmoSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }
}
