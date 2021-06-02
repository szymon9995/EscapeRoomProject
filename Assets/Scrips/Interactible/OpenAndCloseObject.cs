using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseObject : InteractibleBase
{

    private Animator objectAnimation = null;
    [SerializeField] private string stateOpen = null;
    [SerializeField] private string stateClose = null;
    protected override Color color => Color.yellow; 

    private bool isOpen = false;

    [SerializeField] private int itemID = 0;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }

    protected override void Start()
    {
        base.Start();
        if(this.TryGetComponent(out Animator animator))
        {
            objectAnimation = animator;
        }
        
    }

    public override void OnInteract()
    {
        if (itemID == 0 || Inventory.instance.containItem(itemID))
        {
            if (objectAnimation != null)
            {
                if (AnimatorIsPlaying())
                    return;

                if (!isOpen && stateOpen != null)
                {
                    objectAnimation.Play(stateOpen, 0, 0);
                    isOpen = true;
                }
                else if (isOpen && stateClose != null)
                {
                    objectAnimation.Play(stateClose, 0, 0);
                    isOpen = false;
                }
            }
        }
    }

    bool AnimatorIsPlaying()
    {
        return objectAnimation.GetCurrentAnimatorStateInfo(0).length >
               objectAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
