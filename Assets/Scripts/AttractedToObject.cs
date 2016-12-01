using UnityEngine;
using System.Collections;

public class AttractedToObject : MonoBehaviour
{

    public GameObject attractedTo;
    public float strengthOfAttraction = 5.0f;

    void Awake()
    {
        
        
        
    }

    void Start()
    {
        attractedTo = GameObject.FindWithTag("Technician");
    }

    void update()
    {
        
    }

    void FixedUpdate()
    {

        Vector3 direction = attractedTo.transform.position - transform.position;
        //direction.Normalize();
        gameObject.GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
        Debug.Log("I see the technician at " + attractedTo.transform.position);
    }
}