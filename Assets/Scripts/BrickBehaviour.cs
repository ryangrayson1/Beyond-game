using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    private Vector3 startPos;
    private float timeInWorld = 0;
    private float despawnTime = 10;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        timeInWorld += Time.deltaTime;
        if (timeInWorld > despawnTime) {
            Destroy(gameObject);
        }
    }
}
