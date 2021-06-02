using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Assets/Scrips/Inventory/Items/Item",menuName = "InventoryItem")]
public class Item : ScriptableObject
{
    public int ID;
    public string Name;
    public string Descprition;
    public int MaxAmount;
    public int Amount = 1;


    public Item(int ID,string Name,string Descprition, int MaxAmount)
    {
        this.ID = ID;
        this.Name = Name;
        this.Descprition = Descprition;
        this.MaxAmount = MaxAmount;
        this.Amount = 1;
    }

    public void AddToInventory()
    {
        Inventory.instance.AddItem(this);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this);
    }
}
