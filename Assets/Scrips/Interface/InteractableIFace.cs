using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableIFace
{
    [SerializeField]float maxDistance { get; }

    void OnStartHover();
    void OnInteract();
    void OnEndHover();

    void Tick();
    
}
