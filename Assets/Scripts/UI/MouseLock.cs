using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    [SerializeField] private bool shouldLockMouse;

    void Start()
    {
        Cursor.lockState = shouldLockMouse ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
