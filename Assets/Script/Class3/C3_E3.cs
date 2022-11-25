using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.XR;

public class C3_E3 : MonoBehaviour
{
    public Color color = Color.blue;
    public float radiusDisk = 0.2f;

}

[CustomEditor(typeof(C3_E3))]
public class C3_E3_Editor : Editor
{
    private void OnSceneGUI()
    {
        
        var e3 = (C3_E3)target;
        Vector3 sceneCameraForward = SceneView.currentDrawingSceneView.camera.transform.forward;
        float radius = e3.radiusDisk;
        Handles.color = e3.color;
        Handles.DrawWireCube(Vector3.one/2, Vector3.one);//position 0,5 0,5 0,5
       

        Vector3 colorAsPosition = new Vector3(e3.color.r, e3.color.g, e3.color.b);
        
        Handles.DrawSolidDisc(colorAsPosition, sceneCameraForward, radius);
       

        
        
        EditorGUI.BeginChangeCheck();//allow to drag the arrows
        colorAsPosition = Handles.PositionHandle(colorAsPosition, Quaternion.identity);
       

        //ACTUALLy save the new position so we can see it move and drag it around
       e3.color = new Color(Mathf.Clamp01(colorAsPosition.x), Mathf.Clamp01(colorAsPosition.y),Mathf.Clamp01(colorAsPosition.z));

       if (EditorGUI.EndChangeCheck())
       {
          // Debug.Log("colorChanged");
          Undo.RecordObject(e3, "Change Color of Object");
       }

    }
}
