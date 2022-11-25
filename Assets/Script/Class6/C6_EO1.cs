using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

public class C6_EO1 : MonoBehaviour
{
    public Vector3 IncrementByClick;
    public Transform target;


}

[CustomEditor(typeof(C6_EO1))]
public class E01Editor : Editor
{
    public override void OnInspectorGUI()
    {
        var e01 = (C6_EO1)target;

        base.OnInspectorGUI();

        if (GUILayout.Button("Move By Increment" + e01.IncrementByClick)) 
        {
            e01.transform.position += e01.IncrementByClick;
            Debug.Log("Click");
        }
        if (GUILayout.Button("Calcul Necessary Increment to go to target"))
        {
            e01.IncrementByClick = e01.target.position - e01.transform.position;
          
        }
        
    }

    public void OnSceneGUI()
    {
        var e01 = (C6_EO1)target;
        Handles.DrawWireCube((e01.IncrementByClick + e01.transform.position), e01.transform.localScale);
    }
}
