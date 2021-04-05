using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, InteractableIFace
{
    public float maxDistance => 4.0f;

    public void OnEndHover()
    {
        
    }

    public void OnInteract()
    {
        Debug.Log("Picking up Item");
        Destroy(gameObject);
    }

    public void OnStartHover()
    {
        
    }

    public void Tick()
    {

    }
}
