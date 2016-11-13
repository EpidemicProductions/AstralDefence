using UnityEngine;
using System.Collections;

public class CoinDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        DestroyAttached();
    }

    void DestroyAttached()
    {
        // Destroy the pick up item after so many seconds (15).
        Destroy(gameObject, 15);
    }
}
