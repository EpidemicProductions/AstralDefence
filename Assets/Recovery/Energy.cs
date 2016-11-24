using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
    public Text resources;
    public int energyVal;
    public string energyDisp;
    public ParticleSystem pickUp;

    public GameObject stationPosition;
    public GameObject towerPosition;
    private float distance;

    public Text connectCost;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        energyDisp = energyVal.ToString();
        resources.text = energyDisp;
        DetermineTurretCost();
        Debug.Log(distance);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            PickupEnergy();
            Destroy(other.gameObject);
            Instantiate(pickUp, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }

    void PickupEnergy()
    {
        energyVal += 10;
    }

    void DetermineTurretCost()
    {
        distance = Vector3.Distance(stationPosition.transform.position, towerPosition.transform.position);
        float newDistance = distance * 10;
        connectCost.text = newDistance.ToString("N0");
    }
}
