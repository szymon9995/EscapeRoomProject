using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleBase : MonoBehaviour, InteractableIFace
{
    public virtual float maxDistance => 5.0f;


    protected List<MeshRenderer> meshRenderer = new List<MeshRenderer>();
    protected List<Material []> originalMaterials = new List<Material []>();
    protected List<Material []> outlineMateials = new List<Material []>();
    protected Shader outlineShader;
    protected virtual Color color => Color.red;
    protected virtual float outlineWidth => 0.1f;
    protected virtual void Start()
    {

        outlineShader = Shader.Find("Projekt/OutlineShader");
        if (this.TryGetComponent(out MeshRenderer meshTmp))
        {
            meshRenderer.Add(meshTmp);
            originalMaterials.Add(meshTmp.materials);
            List<Material> tmpList = new List<Material>();
            tmpList.AddRange(meshTmp.materials);

            Material tmpOut = new Material(outlineShader);
            tmpOut.SetTexture("_MainTex", meshTmp.material.mainTexture);
            tmpOut.SetColor("_OutlineColor", color);
            //outlineWidth = Mathf.Clamp(outlineWidth, 0.0f, 1.0f);
            tmpOut.SetFloat("_Outline", outlineWidth);

            tmpList.Add(tmpOut);
            outlineMateials.Add(tmpList.ToArray());
        }
        else
        {
            foreach (Transform child in this.transform)
            {
                MeshRenderer[] childRenderer = GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer renderer in childRenderer)
                {
                    meshRenderer.Add(renderer);
                    originalMaterials.Add(renderer.materials);
                    List<Material> tmpList = new List<Material>();
                    tmpList.AddRange(renderer.materials);

                    Material tmpOut = new Material(outlineShader);
                    tmpOut.SetTexture("_MainTex", renderer.material.mainTexture);
                    tmpOut.SetColor("_OutlineColor", color);
                    //outlineWidth = Mathf.Clamp(outlineWidth, 0.0f, 1.0f);
                    tmpOut.SetFloat("_Outline", outlineWidth);

                    tmpList.Add(tmpOut);
                    outlineMateials.Add(tmpList.ToArray());
                }
            }
        }
    }

    public virtual void OnEndHover()
    {
        int i = 0;
        foreach (MeshRenderer renderer in meshRenderer)
        {
            renderer.materials = originalMaterials[i];
            i++;
        }
    }

    public virtual void OnInteract(){ }

    public virtual void OnStartHover()
    {
        int i = 0;
        foreach (MeshRenderer renderer in meshRenderer)
        {
            renderer.materials = outlineMateials[i];
            i++;
        }
            
    }

    public virtual void Tick(){ }
}
