using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Text Name;
    public Text Description;
    public Text Amount;

    public GameObject listParent;
    public GameObject prefabObject;
    public Item errorItem;

    private void InitItemInList(Item item)
    {
        var myNewItem = Instantiate(prefabObject, new Vector3(0, 0, 0), Quaternion.identity);

        GetChildObject.GetChildComponentByName<Text>("Name", myNewItem).text = item.Name;
        GetChildObject.GetChildComponentByName<Text>("ID", myNewItem).text = item.ID.ToString();

        myNewItem.transform.SetParent(listParent.transform);
        myNewItem.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public void DiscplayInteroryList()
    {
        foreach (Transform child in listParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Item item in Inventory.instance.items)
        {
            InitItemInList(item);
        }
    }

    public void DisplayItem(int id)
    {
        Item item = errorItem;
        if (Inventory.instance.items.Exists(itt => itt.ID==id))
            item = Inventory.instance.items.Find(it => it.ID == id);
        Name.text = item.Name;
        Description.text = item.Descprition;
        Amount.text = "Found\n" + item.Amount + "/" + item.MaxAmount;
    }
}
