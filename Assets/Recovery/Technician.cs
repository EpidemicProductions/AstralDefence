using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Technician : MonoBehaviour
{
    public GameObject technician;
    public ParticleSystem tap;

    public GameObject connectDisplay;

    public GameObject turretIdentifier;
    private Vector3 identifierHideLocation;

    public GameObject inputBlocker;

    Vector3 targetPosition;

    public float speed;

    public Vector3 buttonLocation;
    public Vector3 inputBlockerHideLocation;

    private GameObject hitTower;
    

    void Start()
    {
        inputBlocker.transform.position = inputBlockerHideLocation;
        
        inputBlockerHideLocation = new Vector3(0, 0, 0);
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
                
                
                if (hit.collider != inputBlocker.GetComponent<Collider>())
                {
                    Debug.Log("hit");
                   inputBlocker.transform.position = inputBlockerHideLocation;


                    if (hit.collider.GetComponent<Technician>() ||
                        hit.collider.CompareTag("Prop"))
                    {
                        if (connectDisplay.activeInHierarchy)
                        {
                            connectDisplay.SetActive(false);
                        }
                        return;
                    }
                    else if (!hit.collider.GetComponent<Turret>())
                    {

                        targetPosition = hit.point + Vector3.up * 0.5f;

                        Instantiate(tap, hit.point, Quaternion.Euler(90, 0, 0));
                        tap.Play();
                        if (connectDisplay.activeInHierarchy)
                        {

                            connectDisplay.SetActive(false);
                        }
                    }

                    if (hit.collider.GetComponent<Turret>())
                    {
                        hitTower = hit.collider.gameObject;

                        inputBlocker.transform.position = buttonLocation;
                        connectDisplay.SetActive(true);
                        turretIdentifier.transform.position = hit.collider.transform.position;
                    }
                    else
                    {
                       turretIdentifier.transform.position = identifierHideLocation;
                    }
                    
                }
                
            }
        }
        technician.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }

    public void ConnectTower()
    {
        Debug.Log("1st");

        if(GetComponent<Energy>().energyVal >= GetComponent<Energy>().connectionCost)
        {
            hitTower.GetComponent<Turret>().active = true;
            Debug.Log("2nd");
            GetComponent<Energy>().energyVal -= GetComponent<Energy>().connectionCost;
        }
        
    }
}