using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class C6_E03 : MonoBehaviour
{
    public Transform Start;
    public Transform End;
    public Transform ObjectToMove;
    [Range(0,1)]public float percentageOfMove;
    public bool useLerp;

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(Start.position, End.position);
    }

    public void OnValidate()
    {
        if (useLerp)
        {
            Vector3 offset = Vector3.Lerp(Start.position, End.position, percentageOfMove);

            ObjectToMove.position = offset;
        }
        else
        {
            Vector3 offset = (End.position - Start.position) * percentageOfMove;

            ObjectToMove.position = Start.position + offset;
        }
        
    }
}
