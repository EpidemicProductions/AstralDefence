using UnityEngine;
using System.Collections;

public class Technician : MonoBehaviour
{
    public GameObject technician;
    public ParticleSystem tap;
    


    Vector3 targetPosition;

    public float speed;

    void Start()
    {

        targetPosition = transform.position;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<Turret>() ||
                    hit.collider.GetComponent<Technician>() ||
                    hit.collider.CompareTag("Prop"))
                {
                    return;
                }
                else
                {

                    targetPosition = hit.point + Vector3.up * 0.5f;

                    Instantiate(tap, hit.point, Quaternion.Euler(90, 0, 0));
                    tap.Play();
                    Debug.Log(hit.collider.name);
                }
                
            }
        }
        technician.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.GetComponent<Turret>())
        {
            other.GetComponent<Turret>().active = true;
        }
    }   
}