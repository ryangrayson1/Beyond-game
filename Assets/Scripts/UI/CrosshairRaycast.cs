
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A small script to toggle the crosshair visiblity and color.
/// </summary>
public class CrosshairRaycast : MonoBehaviour
{
    [SerializeField] private Sprite crosshairInactive;
    [SerializeField] private Sprite crosshairActive;
    [SerializeField] private Transform playerXf; // should be camera xf
    private float range = 40;

    private Vector3 boxSize = new Vector3(1, 10, 1);
    private Image image;
    private bool onTarget;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (image.enabled)
        {
            if (Physics.BoxCast(playerXf.position, boxSize, playerXf.forward, out RaycastHit hit) && hit.distance <= range)
            //if (Physics.Raycast(playerXf.position, playerXf.forward, out RaycastHit hit) && hit.distance <= range)
            {
                onTarget = true;
            }
            else
            {
                onTarget = false;
            }
            image.sprite = onTarget ? crosshairActive : crosshairInactive;
        }
    }

    public void SetVisible(bool enabled)
    {
        image.enabled = enabled;
    }

    public bool IsOnTarget()
    {
        return onTarget;
    }
}
