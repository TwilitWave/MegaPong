﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public float velocityScale;
    public Rigidbody sphereBody;
    public Vector3 velocity;

    // Use this for initialization
    void Awake() {
        Debug.Log("Initializing new ball.");
        sphereBody = GetComponent<Rigidbody>();
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
    }

    void Update () {
        sphereBody.velocity = velocity;
    }
}
