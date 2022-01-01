using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * -100, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(transform.forward * -100, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
    //        Vector3 dir = collision.gameObject.transform.position - transform.position;
    //        dir.y = 0;
    //        Debug.Log(dir.normalized);
    //        rb.AddForce(dir.normalized * 10, ForceMode.Impulse);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().hitObject = true;

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = collision.gameObject.transform.position - transform.position;
            dir.y = 0;
            Debug.Log(dir.normalized);
            rb.AddForce(dir.normalized * 100, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().hitObject = false;
        }
    }
}
