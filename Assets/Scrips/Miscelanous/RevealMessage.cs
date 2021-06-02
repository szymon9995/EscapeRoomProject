using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealMessage : MonoBehaviour
{
    public GameObject flashLight;
    private Renderer rendererM;
    private void Start()
    {
        rendererM = this.GetComponent<Renderer>();
    }
    void Update()
    {
        if(flashLight!=null)
        {
            if(flashLight.activeSelf == true)
            {
                rendererM.material.SetVector("_LightPos", flashLight.transform.position);
                rendererM.material.SetVector("_LightDir", flashLight.transform.forward);
            }
            else
            {
                rendererM.material.SetVector("_LightPos", new Vector3(0,0,0));
                rendererM.material.SetVector("_LightDir", new Vector3(0, 0, 0));
            }
        }
    }
}
