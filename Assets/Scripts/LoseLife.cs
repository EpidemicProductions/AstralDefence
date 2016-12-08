using UnityEngine;
using System.Collections;

public class LoseLife : MonoBehaviour {
    public GameObject soundController;
    public GameObject tech;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            tech.GetComponent<Energy>().heartsVal -= 1;
            soundController.GetComponent<SoundController>().healthDropPlay();
        }
    }
}
