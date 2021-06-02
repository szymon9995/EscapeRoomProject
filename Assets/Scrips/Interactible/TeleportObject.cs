using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : InteractibleBase
{
    protected override Color color => Color.black;

    public override void OnInteract()
    {
        if(Inventory.instance.containItem(3))
        {
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
}
