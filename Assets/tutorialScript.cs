using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    By Ryan Grayson
*/

public class tutorialScript : MonoBehaviour
{

    public Text tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 2 && Time.timeSinceLevelLoad < 5){
            tutorialText.text = "Press Space to Get Started!";
        }
    }
}
