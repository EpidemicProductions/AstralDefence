using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    //Stops music from destroying on load and if it is already playing
    public static AudioController Instance;
    void Awake()
    {

        if (Instance)
            DestroyImmediate(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;

        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
}
