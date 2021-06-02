using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHold : InteractibleBase
{

    public Transform heldParent;

    private bool isHeld=false;
    public override float maxDistance => 7.0f;
    protected override Color color => Color.blue;
    //[SerializeField] private float moveForce = 250.0f;
    [SerializeField] private float dragForce = 5.0f;


    public override void OnStartHover()
    {
        base.OnStartHover();
        if (isHeld)
        {
            DropObject();
            isHeld = false;
        }
    }

    public override void OnInteract()
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

    public override void OnEndHover()
    {
        base.OnEndHover();
        if (isHeld)
        {
            DropObject();
            isHeld = false;
        }
    }

    public override void Tick()
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
        if(Vector3.Distance(this.transform.position,heldParent.position)>0.01f)
        {
            //Vector3 moveDir = (heldParent.position - this.transform.position);
            //this.GetComponent<Rigidbody>().AddForce(moveDir*moveForce);
            this.transform.position = heldParent.position;
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
