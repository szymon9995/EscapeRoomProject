using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControl : MonoBehaviour
{
    public GameObject flashLight;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Inventory.instance.containItem(2))
        {
            flashLight.SetActive(!flashLight.activeSelf);
        }
    }
}
