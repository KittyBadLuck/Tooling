using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpArrow : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 end = origin + Vector3.up;
        Color color = Color.green;

        Debug.DrawLine(origin, end, color);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right);
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
