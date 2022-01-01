using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBrick : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    private float speed = 10;

    public void Throw()
    {
        GameObject brick = Instantiate(brickPrefab, transform.position - 0.5f * Vector3.right, brickPrefab.transform.rotation);
        Rigidbody rb = brick.GetComponent<Rigidbody>();
        rb.AddForce(speed * transform.forward, ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)), ForceMode.Impulse);
    }
}
