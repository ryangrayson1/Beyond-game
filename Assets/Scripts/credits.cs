using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    public GameObject creditsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toCredits(){
        creditsPanel.SetActive(true);
    }

    public void toMenu(){
        creditsPanel.SetActive(false);
    }
}
