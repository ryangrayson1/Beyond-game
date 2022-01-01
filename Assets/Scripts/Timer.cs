using UnityEngine;

/**
 * By Eric Weng
 * 
 * A general purpose timer script that counts down from a set value to 0.
 */
public class Timer : MonoBehaviour
{
    [SerializeField] public float maxValue; // how long to count for
    public float value { get; private set; } // current time
    private bool started = false; // is counting

    /* Script Methods */

    private void Start()
    {
        value = maxValue;
    }

    private void Update()
    {
        if (started) value -= Time.deltaTime;
    }

    /* Game Methods */

    public void Reset()
    {
        value = maxValue;
    }

    public void CountDown(float dt)
    {
        value -= dt;
    }

    /* Field Getters */

    public void SetStarted(bool started)
    {
        this.started = started;
    }

    public bool IsReady()
    {
        return value <= 0;
    }

    public bool IsStarted()
    {
        return started;
    }
}

