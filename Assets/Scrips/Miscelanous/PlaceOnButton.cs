using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnButton : MonoBehaviour
{

    public ElevatorController controller;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Weight")
        {
            if (controller != null)
                controller.EvelatorUp();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Weight")
        {
            if (controller != null)
                controller.EvelatorDown();
        }
    }
}
