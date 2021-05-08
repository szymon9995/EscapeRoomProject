using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : InteractibleBase
{
    private ResponseIFace responseIFace = null;
    [SerializeField] private GameObject responseObject = null;


    protected override void Start()
    {
        base.Start();
        if(responseObject!=null)
        {
            responseIFace = responseObject.GetComponent<ResponseIFace>();
        }
    }


    public override void OnInteract()
    {
        if(responseIFace != null)
        {
            responseIFace.Response();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
