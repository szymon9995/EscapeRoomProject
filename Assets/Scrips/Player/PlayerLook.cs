﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensivity = 100f;
    public Transform playerBody;

    private float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mosueY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        yRotation -= mosueY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
