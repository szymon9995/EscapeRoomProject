using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : InteractibleBase
{
    public Item item;

    protected override Color color => Color.blue;

    public override void OnInteract()
    {

        if (item != null)
            item.AddToInventory();
        else
            Debug.LogWarning("Item not assigned to picked up object");
        transform.position = new Vector3(-100, -100, -100);
    }
}
