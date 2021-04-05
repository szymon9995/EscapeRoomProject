using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public int id;
    new public string name;
    public string description;
    public Sprite icon;

    public Item(int id,string name,string description,Sprite icon)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + name);
    }
}
