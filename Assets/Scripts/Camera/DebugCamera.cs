using UnityEngine;
using EZCameraShake;

public class DebugCamera : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    [SerializeField] private float yaw = 180.0f; // can set starting rotation
    private float pitch = 0.0f;

    public float seconds = 5f;
    public float timer;
    public Vector3 difference;
    public float percent;
    public Vector3 added;

    public float yPos;
    public float zPos;

    void Start()
    {
        CameraShaker.Instance.StartShake(1.5f, 1f, 1f);
    }

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        // Clamp pitch so we don't get weird angles
        if (pitch < -90f) pitch = -90f;
        else if (pitch > 90f) pitch = 90f;

        if (Input.GetKey(KeyCode.LeftShift) && GameObject.Find("SceneControl").GetComponent<UIController>().powerupMode)
        {
            if (timer <= seconds)
            {
                // basic timer
                timer += Time.deltaTime;
                // percent is a 0-1 float showing the percentage of time that has passed on our timer!
                percent = timer / seconds;
                // multiply the percentage to the difference of our two positions
                // and add to the start
                added = new Vector3(0f, yPos, zPos) + (new Vector3(0f, 2.9f, -0.6f) - new Vector3(0f, yPos, zPos)) * percent;
                transform.position = transform.parent.position + added;
            }
        }
        else
        {
            transform.position = transform.parent.position + new Vector3(0f, yPos, zPos);
            timer = 0;
        }

        transform.eulerAngles = new Vector3(10.0f, yaw, 0.0f);
    }
}
