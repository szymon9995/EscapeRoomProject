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

    public List<Item> items;

    public void AddItem(Item item)
    {
        if (items.Exists(it => it.ID == item.ID))
            items.Find(i => i.ID == item.ID).Amount++;
        else
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

    public bool containItem(int id)
    {
        return items.Exists(item => item.ID == id);
    }

    public bool containItemAndUse(int id)
    {
        if (items.Exists(item => item.ID == id) == false)
            return false;

        RemoveItem(items.Find(it=> it.ID == id) );
        return true;
    }
}
