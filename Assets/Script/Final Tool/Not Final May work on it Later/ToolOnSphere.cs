using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Object = UnityEngine.GameObject;

public class ToolOnSphere : EditorWindow
{ 
    public float maxDistanceDetect = 10f;
    public float clampOffset = 5;
    public Vector3 basePosition;
    public string tagToDetect = "Sphere";
    public GameObject selectedObject;
    public bool noSurfaceFound = false;
    public bool useSnapToSurface;

    [MenuItem("Window/SnapToSurface")]
    private static void Create()
    {
        var window = EditorWindow.GetWindow<ToolOnSphere>();
        window.titleContent = new GUIContent("SnapToSurface");
        window.Show();
    }

    private void OnGUI()
    {
        useSnapToSurface = EditorGUILayout.Toggle("Use Snap to Surface", useSnapToSurface);
        maxDistanceDetect = EditorGUILayout.FloatField("max Distance Detect", maxDistanceDetect);
            clampOffset = EditorGUILayout.FloatField("Distance To Surface", clampOffset);
            basePosition = EditorGUILayout.Vector3Field("Surface Position", basePosition);
            tagToDetect = EditorGUILayout.TextField("Tag of Surface", tagToDetect);
            selectedObject = (GameObject)EditorGUILayout.ObjectField("Selected Object", selectedObject, typeof(GameObject) , true);
            GetSelection();
            if (noSurfaceFound)
            {
                EditorGUILayout.HelpBox("No surface was detected, verify that your tag is correctly typed, and assigned to the surface", MessageType.Warning);
            }

    }

    private void GetSelection()
    {
        selectedObject = Selection.activeGameObject;
    }

    
    private void OnInspectorUpdate()
    {
        
       /* if (useSnapToSurface) 
        {
            
            GameObject targetGameobject = FindClosestSphere(maxDistanceDetect);
            if (targetGameobject == null )
            {
                noSurfaceFound = true;
                return;
            }
            Collider targetCollider = targetGameobject.GetComponent<Collider>();
            Vector3 targetClosestPoint = targetCollider.ClosestPoint(basePosition);
            basePosition = targetClosestPoint;
        
            Vector3 directionFromSphereToSnapE = selectedObject.transform.position - targetCollider.transform.position;
            Vector3 offsetClamped = directionFromSphereToSnapE.normalized * clampOffset;
            Vector3 offsetSlider;

       
            selectedObject.transform.position = targetClosestPoint + offsetClamped;
        
            EditorGUI.BeginChangeCheck();
            basePosition = Handles.PositionHandle(basePosition, Quaternion.identity);
            Handles.DrawLine(basePosition, selectedObject.transform.position, 1);

            offsetSlider = Handles.Slider((basePosition + offsetClamped), directionFromSphereToSnapE, 3, Handles.ArrowHandleCap,0.001f);
            offsetSlider = offsetSlider - basePosition;
            clampOffset = offsetSlider.magnitude;
            if (EditorGUI.EndChangeCheck())
            {
                //Debug.Log("Test");
                Undo.RecordObject(selectedObject, "Change Detected");
            }
            
            GameObject FindClosestSphere(float maxdistance)
            {
                GameObject[] gos;
                gos = GameObject.FindGameObjectsWithTag(tagToDetect);
                GameObject closest = null;
                Vector3 position = selectedObject.transform.position;
                foreach (GameObject go in gos)
                {
                    Vector3 diff = go.transform.position - position;
                    //account for radius of sphere as well.
                    float curDistance = diff.magnitude - go.transform.lossyScale.magnitude;
                    if (curDistance < maxdistance)
                    {
                        closest = go;
                        maxdistance = curDistance;
                    }
                }
                return closest;

            }
                    
        }*/

        Repaint();
    }
    
}

/*[CustomEditor(typeof(ToolOnSphere))]
public class SnapToSurfaceEditor : Editor
{
    private void OnSceneGUI()
    {
        Debug.Log("test");
        var snap = (ToolOnSphere)target;
    
        if (snap.useSnapToSurface) 
        {
            GameObject targetGameobject = FindClosestSphere(snap.maxDistanceDetect);
            if (targetGameobject == null )
            {
                snap.noSurfaceFound = true;
                return;
            }
            Collider targetCollider = targetGameobject.GetComponent<Collider>();
            Vector3 targetClosestPoint = targetCollider.ClosestPoint(snap.basePosition);
            snap.basePosition = targetClosestPoint;
        
            Vector3 directionFromSphereToSnapE = snap.selectedObject.transform.position - targetCollider.transform.position;
            Vector3 offsetClamped = directionFromSphereToSnapE.normalized * snap.clampOffset;
            Vector3 offsetSlider;

       
            snap.selectedObject.transform.position = targetClosestPoint + offsetClamped;
        
            EditorGUI.BeginChangeCheck();
             snap.basePosition = Handles.PositionHandle(snap.basePosition, Quaternion.identity);
            Handles.DrawLine(snap.basePosition, snap.selectedObject.transform.position, 1);

            offsetSlider = Handles.Slider((snap.basePosition + offsetClamped), directionFromSphereToSnapE, 3, Handles.ArrowHandleCap,0.001f);
            offsetSlider = offsetSlider - snap.basePosition;
            snap.clampOffset = offsetSlider.magnitude;
            if (EditorGUI.EndChangeCheck())
            {
                //Debug.Log("Test");
                Undo.RecordObject(snap.selectedObject, "Change Detected");
            }
            
            GameObject FindClosestSphere(float maxdistance)
            {
                GameObject[] gos;
                gos = GameObject.FindGameObjectsWithTag(snap.tagToDetect);
                GameObject closest = null;
                Vector3 position = snap.selectedObject.transform.position;
                foreach (GameObject go in gos)
                {
                    Vector3 diff = go.transform.position - position;
                    //account for radius of sphere as well.
                    float curDistance = diff.magnitude - go.transform.lossyScale.magnitude;
                    if (curDistance < maxdistance)
                    {
                        closest = go;
                        maxdistance = curDistance;
                    }
                }
                return closest;

            }
                    
        }
    }

    
    

}*/
