using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/*
by Ryan Grayson
*/

[RequireComponent(typeof (Slider))]
public class AudioSlider : MonoBehaviour
{
    Slider slider {
        get { return GetComponent<Slider>();}
    }

    public AudioMixer mixer;
    public string volumeName;

    public void UpdateValueOnChange(float value){
        mixer.SetFloat(volumeName, Mathf.Log(value) * 20f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
