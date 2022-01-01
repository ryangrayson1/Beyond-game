using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    Vector3 move;
    public float fallTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fallTime >= 7){
            transform.position = new Vector3(0, 35, 60);
            fallTime = 0;
        }
        else if (fallTime < 7){
            fallTime += Time.deltaTime;
            move = new Vector3(0, -10f, 0);
            transform.Translate(move * Time.deltaTime);
        }
    }
}
