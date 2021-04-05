using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour, InteractableIFace
{
    [SerializeField] private Animator doorAnimation = null;

    public float maxDistance => 5.0f;

    public void OnEndHover()
    {
        Debug.Log("Starting hovering on doorTriger");
    }

    public void OnInteract()
    {
        AnimatorStateInfo tmp = doorAnimation.GetCurrentAnimatorStateInfo(0);
        if (tmp.IsName("Idle") || tmp.IsName("DoorClose"))
        {
            doorAnimation.Play("DoorOpen", 0, 0);
            return;
        }
        if (tmp.IsName("DoorOpen"))
        {
            doorAnimation.Play("DoorClose", 0, 0);
        }
    }

    public void OnStartHover()
    {
        Debug.Log("Ending hovering on doorTriger");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }

    public void Tick()
    {

    }

    /*
    private void OnMouseDown()
    {
        AnimatorStateInfo tmp = doorAnimation.GetCurrentAnimatorStateInfo(0);
        if (tmp.IsName("Idle") || tmp.IsName("DoorClose"))
        {
            doorAnimation.Play("DoorOpen", 0, 0);
            return;
        }
        if(tmp.IsName("DoorOpen"))
        {
            doorAnimation.Play("DoorClose", 0, 0);
        }
        
    }
    */
}
