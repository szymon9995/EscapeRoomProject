using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDoor : MonoBehaviour , ResponseIFace
{
    private Animator doorAnimation = null;

    void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }

    public void Response()
    {
        if(doorAnimation !=null)
        {
            if (AnimatorIsPlaying())
                return;

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
    }

    bool AnimatorIsPlaying()
    {
        return doorAnimation.GetCurrentAnimatorStateInfo(0).length >
               doorAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
