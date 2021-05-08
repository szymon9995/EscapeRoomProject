using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    private Animator evelatorAnimation = null;

    void Start()
    {
        evelatorAnimation = GetComponent<Animator>();
    }

    public void EvelatorUp()
    {
        if (evelatorAnimation != null)
        {
            if (AnimatorIsPlaying())
                return;

            AnimatorStateInfo tmp = evelatorAnimation.GetCurrentAnimatorStateInfo(0);

            if (tmp.IsName("Idle") || tmp.IsName("EvelatorUp"))
            {
                evelatorAnimation.Play("EvelatorDown", 0, 0);
                return;
            }
        }
    }

    public void EvelatorDown()
    {
        if (evelatorAnimation != null)
        {
            if (AnimatorIsPlaying())
                return;

            AnimatorStateInfo tmp = evelatorAnimation.GetCurrentAnimatorStateInfo(0);

            if (tmp.IsName("EvelatorUp"))
            {
                evelatorAnimation.Play("EvelatorDown", 0, 0);
            }
        }
    }

    bool AnimatorIsPlaying()
    {
        return evelatorAnimation.GetCurrentAnimatorStateInfo(0).length >
               evelatorAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
