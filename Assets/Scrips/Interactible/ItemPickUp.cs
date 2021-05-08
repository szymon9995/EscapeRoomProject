using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : InteractibleBase
{

    public override void OnInteract()
    {
        Destroy(gameObject);
    }
}
