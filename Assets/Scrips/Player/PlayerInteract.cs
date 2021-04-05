using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distance = 10.0f;

    private Camera playerCamera;
    private InteractableIFace curTarget;


    public void Awake()
    {
        playerCamera = Camera.main;
    }

    public void Update()
    {
        RaycastInteract();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(curTarget!=null)
            {
                curTarget.OnInteract();
            }
        }

        if(curTarget!=null)
        {
            curTarget.Tick();
        }
    }

    private void RaycastInteract()
    {
        RaycastHit hit;

        Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit, distance))
        {
            InteractableIFace target = hit.collider.GetComponent<InteractableIFace>();
            if(target != null)
            {
                if(hit.distance <=target.maxDistance)
                {
                    if(target==curTarget)
                    {
                        return;
                    }
                    else if(curTarget!=null)
                    {
                        curTarget.OnEndHover();
                        curTarget = target;
                        curTarget.OnStartHover();
                        return;
                    }
                    else
                    {
                        curTarget = target;
                        curTarget.OnStartHover();
                        return;
                    }
                }
            }
        }

        if(curTarget!=null)
        {
            curTarget.OnEndHover();
            curTarget = null;
            return;
        }
        
    }
}