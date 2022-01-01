using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeForce : MonoBehaviour
{
    public Vector3 force;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void push()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = force;
    }
}
