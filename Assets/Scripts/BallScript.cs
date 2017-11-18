using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Vector2 velocity = new Vector2();
    public float velocityScale;

    // Use this for initialization
    void Start () {
        //Random Speed
        velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * velocityScale;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            velocity *= -1;
        }
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    void Update () {
        
        transform.Translate(velocity.x, velocity.y, 0);
    }
}
