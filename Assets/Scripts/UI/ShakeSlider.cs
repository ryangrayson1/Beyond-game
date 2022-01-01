using UnityEngine;
using UnityEngine.UI;

public class ShakeSlider : MonoBehaviour
{
    private Slider slider;
    private Vector3 startPos;

    private void Start()
    {
        slider = GetComponent<Slider>();
        startPos = slider.transform.position;
    }

    private void Update()
    {
        float val = slider.normalizedValue;
        float intensity;

        if (val <= 0.25f)
        {
            intensity = 10;
        }
        else if (val <= 0.5f)
        {
            intensity = 5;
        }
        else
        {
            intensity = 0;
        }
        float angle = Random.Range(0, 360);
        SetPosition(startPos + intensity * (Quaternion.Euler(0, 0, angle) * Vector3.up));
    }

    private void SetPosition(Vector3 pos)
    {
        slider.transform.position = pos;
    }
}
