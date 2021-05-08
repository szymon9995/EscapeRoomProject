using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public float height = 1.1f;
    
    private Camera playerCamera;
    private Vector3 originalPos;


    void Start()
    {
        playerCamera = Camera.main;
        originalPos = this.transform.InverseTransformPoint(playerCamera.transform.position);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x,this.transform.position.y + originalPos.y - height, playerCamera.transform.position.z);
        }
        else
        {
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, this.transform.position.y + originalPos.y, playerCamera.transform.position.z);
        }
    }
}
