using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInfo : MonoBehaviour
{
    public GameObject helpInfo;
    public GameObject inventoryInfo;

    private void Start()
    {
        ToogleDisplayInfo(true);
    }

    public void ToogleDisplayInfo(bool toHelp)
    {
        if(!toHelp)
        {
            inventoryInfo.SetActive(true);
            helpInfo.SetActive(false);
            inventoryInfo.GetComponent<InventoryDisplay>().DiscplayInteroryList();
        }
        else
        {
            inventoryInfo.SetActive(false);
            helpInfo.SetActive(true);
        }
    }

}
