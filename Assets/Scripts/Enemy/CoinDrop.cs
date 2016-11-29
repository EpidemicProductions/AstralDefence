using UnityEngine;
using System.Collections;

public class CoinDrop : MonoBehaviour {
    public float speed;
    

	// Use this for initialization
	void Start ()
    {
        speed = 10f;
        DestroyAttached();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, gameObject.GetComponent<Technician>().transform.position, speed * Time.deltaTime);
    }

    void DestroyAttached()
    {
        // Destroy the pick up item after so many seconds (15).
        Destroy(gameObject, 15);
    }
}
