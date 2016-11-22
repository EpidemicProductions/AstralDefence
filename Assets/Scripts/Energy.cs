using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
    public Text resources;
    public int energyVal;
    public string energyDisp;
    public ParticleSystem pickUp;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        energyDisp = energyVal.ToString();
        resources.text = energyDisp;
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
}
