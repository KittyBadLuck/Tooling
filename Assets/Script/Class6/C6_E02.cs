using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class C6_E02 : MonoBehaviour
{
    public Vector3 scaleIncrement = Vector3.one;
    public Transform target;
}

[CustomEditor(typeof(C6_E02))]
public class E02Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var e02 = (C6_E02)target;

        if (GUILayout.Button("Stretch by Click " + e02.scaleIncrement))
        {
            var newScale = e02.transform.localScale;
            newScale.Scale(e02.scaleIncrement);
            e02.transform.localScale = newScale;
        }

        if (GUILayout.Button("Calculate necessary Strech to match Target Scaling"))
        {
            Vector3 localScale = e02.transform.localScale;
            Vector3 targetScale = e02.target.localScale;
            Vector3 necessaryStretch = new Vector3(targetScale.x / localScale.x, targetScale.y / localScale.y,
                targetScale.z / localScale.z);

            e02.scaleIncrement = necessaryStretch;

        }
        
    }
}
