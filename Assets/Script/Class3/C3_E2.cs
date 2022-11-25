using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class C3_E2 : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {

        Vector3 localDown = -transform.up;
        Vector3 globalDown = Vector3.down;
        
        DrawLineToIntersection(localDown, Gizmos.color = new Color(0.62f, 0.16f, 0.76f, 1f));
        DrawLineToIntersection(globalDown, Gizmos.color = new Color(0.08f, 0.17f, 0.76f, 1f));

    }

    void DrawLineToIntersection(Vector3 rayDirection, Color color)
    {
        var ray = new Ray(transform.position, rayDirection);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hitInfo);

        if (hasHit)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(transform.position, hitInfo.point);
            Gizmos.DrawSphere(hitInfo.point, 0.1f);
        }
    }
}
