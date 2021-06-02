using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonScript : MonoBehaviour
{
    
    public void SetAsMainItem()
    {
        List<Text> texts = new List<Text>();
        int id = 0;
        foreach(Text comp in this.GetComponentsInChildren<Text>(true))
        {
            if (comp.name == "ID") id = int.Parse(comp.text);
        }
        InventoryDisplay display = FindObjectOfType<InventoryDisplay>();
        display.DisplayItem(id);
    }
}
