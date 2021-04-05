using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHold : MonoBehaviour, InteractableIFace
{

    public Transform heldParent;
    public float maxDistance => 6.0f;
    private bool isHeld=false;
    [SerializeField] private float moveForce = 250.0f;
    [SerializeField] private float dragForce = 5.0f;

    public void OnStartHover()
    {
        if (isHeld)
        {
            DropObject();
            isHeld = false;
        }
    }

    public void OnInteract()
    {
        if (!isHeld)
        {
            PickUpObject();
        }
        else
        {
            DropObject();
        }
    }

    public void OnEndHover()
    {
        if (isHeld)
        {
            DropObject();
            isHeld = false;
        }
    }

    public void Tick()
    {
        if (isHeld)
            MoveObject();
    }

    private void PickUpObject()
    {
        if(this.GetComponent<Rigidbody>())
        {
            Rigidbody rigBody = this.GetComponent<Rigidbody>();
            rigBody.useGravity = false;
            rigBody.drag = dragForce;

            rigBody.transform.position = heldParent.position;

            isHeld = true;
        }
    }

    private void MoveObject()
    {
        if(Vector3.Distance(this.transform.position,heldParent.position)>0.1f)
        {
            Vector3 moveDir = (heldParent.position - this.transform.position);
            this.GetComponent<Rigidbody>().AddForce(moveDir*moveForce);
        }
    }

    private void DropObject()
    {
        Rigidbody rigBody = this.GetComponent<Rigidbody>();
        rigBody.useGravity = true;
        rigBody.drag = 1;

        isHeld = false;
    }
}
