using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEffect : MonoBehaviour
{
    public ParticleSystem ps;
    public Vector3 worldPosition;
    //public GameObject cam;

    public bool isLocked = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            isLocked = !isLocked;
        }

        RaycastHit _hit = new RaycastHit();
        if (Input.GetMouseButtonDown(0))
        {
            //if (Physics.Raycast(transform.position, transform.forward, out _hit) && _hit.distance <= 25)
            if (Physics.BoxCast(transform.position, new Vector3(1, 10, 1), transform.forward, out _hit) && _hit.distance <= 50)
            {
                Debug.Log("hit");
                if (_hit.transform.tag == "Shootable")
                {
                    //ParticleSystem effect = Instantiate(ps);
                    //effect.Stop();
                    //effect.gameObject.transform.position = transform.position;
                    //effect.gameObject.transform.rotation = transform.rotation;
                    //effect.Play();


                    Rigidbody rb = _hit.transform.GetComponent<Rigidbody>();
                    if (rb.mass < 50)
                    {
                        foreach (BoxCollider col in _hit.transform.GetComponents<BoxCollider>())
                        {
                            col.isTrigger = true;
                        }
                    }
                    rb.isKinematic = false;
                    rb.AddForce(transform.position - rb.transform.position, ForceMode.Impulse);
                    //rb.AddForce(transform.up * 10, ForceMode.Impulse);

                    StartCoroutine(delete(_hit.transform.gameObject));
                }
            }
        }
    }

    IEnumerator delete(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        Destroy(obj);
    }
}
