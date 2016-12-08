using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
    public GameObject soundController;

    public int heartsVal;
    public Text heartsText;
    public string heartsDisp;
    public int startingHearts;

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
        heartsVal = startingHearts;
	}
	
	// Update is called once per frame
	void Update () {
        energyDisp = energyVal.ToString();
        heartsDisp = heartsVal.ToString();
        resources.text = energyDisp;
        heartsText.text = heartsDisp;
        DetermineTurretCost();
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
        soundController.GetComponent<SoundController>().pickupPlay();
    }

    void DetermineTurretCost()
    {
        distance = Vector3.Distance(stationPosition.transform.position, towerPosition.transform.position);
        connectionCost = (int)distance  * 10;
        connectCost.text = connectionCost.ToString("N0");
    }
}
