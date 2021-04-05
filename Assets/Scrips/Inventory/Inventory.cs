using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Inventory");
            return;
        }
            
        instance = this;
    }

    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void ClearInventory()
    {
        items.Clear();
    }
}
