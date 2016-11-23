using UnityEngine;
using System.Collections;

public class MoveBetween : MonoBehaviour {
    public Vector3 pos1 = new Vector3(18, 0, 0);
    public Vector3 pos2 = new Vector3(-18, 0, 0);
    public float speed = 1.0f;

    void Update()
    {
        //Use Mathf.PingPong() to bounce an object between 2 postions.
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
