using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChildObject : MonoBehaviour
{
    public static T GetChildComponentByName<T>(string name, GameObject childObject) where T : Component
    {
        foreach (T component in childObject.GetComponentsInChildren<T>(true))
        {
            if (component.gameObject.name == name)
            {
                return component;
            }
        }
        return null;
    }
}
