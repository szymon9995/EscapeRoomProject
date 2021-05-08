using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInteactToParent : MonoBehaviour, InteractableIFace
{
    public float maxDistance => 5.0f;
    private GameObject parent;
    private InteractableIFace parentIFace;
    private void Start()
    {
        parent = this.transform.parent.gameObject;
        if(parent!=null)
        {
            parentIFace = parent.GetComponent<InteractableIFace>();
        }
    }

    public void OnEndHover()
    {
        if (parentIFace != null)
            parentIFace.OnEndHover();
    }

    public void OnInteract()
    {
        if (parentIFace != null)
            parentIFace.OnInteract();
    }

    public void OnStartHover()
    {
        if (parentIFace != null)
            parentIFace.OnStartHover();
    }

    public void Tick()
    {
        if (parentIFace != null)
            parentIFace.Tick();
    }
}
