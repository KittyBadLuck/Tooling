using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3_E1 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (transform.childCount > 0 && transform.localScale != Vector3.one)
        {
            Vector3 center = transform.position;
            Vector3 scale = transform.localScale;
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(center, scale);
            Gizmos.DrawIcon(center, "circle", false);
        }
       
    }
}
