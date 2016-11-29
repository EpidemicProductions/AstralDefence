using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
    public int startingEnergy;
    public Text resources;
    public int energyVal;
    public string energyDisp;
    public ParticleSystem pickUp;

    public GameObject stationPosition;
    public GameObject towerPosition;
    private float distance;

    public int connectionCost;
    public Text connectCost;

	// Use this for initialization
	void Start () {
        energyVal = startingEnergy;
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
        connectionCost = (int)distance  * 10;
        connectCost.text = connectionCost.ToString("N0");
    }
}
