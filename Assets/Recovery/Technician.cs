using UnityEngine;
using System.Collections;

public class Technician : MonoBehaviour
{
    public GameObject technician;
    public ParticleSystem tap;

    public GameObject connectDisplay;

    public GameObject turretIdentifier;
    private Vector3 identifierHideLocation;

    Vector3 targetPosition;

    public float speed;
    

    void Start()
    {
        connectDisplay.SetActive(false);
        targetPosition = transform.position;
        identifierHideLocation = new Vector3(0, 0, 0);
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.GetComponent<Technician>() ||
                    hit.collider.CompareTag("Prop"))
                {
                    if(connectDisplay.activeInHierarchy)
                    {
                        connectDisplay.SetActive(false);
                    }
                    return;
                }
                else if(!hit.collider.GetComponent<Turret>())
                {

                    targetPosition = hit.point + Vector3.up * 0.5f;

                    Instantiate(tap, hit.point, Quaternion.Euler(90, 0, 0));
                    tap.Play();
                    Debug.Log(hit.collider.name);
                    if (connectDisplay.activeInHierarchy)
                    {
                        connectDisplay.SetActive(false);
                    }
                }

                if(hit.collider.GetComponent<Turret>())
                {
                    connectDisplay.SetActive(true);
                    turretIdentifier.transform.position = hit.collider.transform.position;
                }
                else
                {
                    turretIdentifier.transform.position = identifierHideLocation;
                }
                ConnectTower(hit);   
            }
        }
        technician.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }

    public void ConnectTower(RaycastHit hit)
    {
        hit.collider.GetComponent<Turret>().active = true;
        Debug.Log("im running");
    }

}