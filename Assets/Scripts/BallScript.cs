using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public float velocityScale;
    public Rigidbody sphereBody;
    public Vector3 velocity;

    // Use this for initialization
    void OnAwake() {
        sphereBody = GetComponent<Rigidbody>();
        sphereBody.velocity = new Vector2(5, 0);
    }

    void Start () {
        
    }

    public void SetVelocity(Vector2 i_velocity)
    {
        sphereBody.velocity = i_velocity;
        velocity = i_velocity;
    }
    public Vector2 GetVelocity()
    {
        return sphereBody.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            velocity = sphereBody.velocity;
        }
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    void Update () {
        sphereBody.velocity = velocity;
    }
}
