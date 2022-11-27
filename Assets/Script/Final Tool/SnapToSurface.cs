using System;
using UnityEngine;
using UnityEditor;


public class SnapToSurface : MonoBehaviour
{
    public bool UseSnap = false;
    public bool SnapRotation = false;
    [Tooltip("Assign the same tag to the surface you want to detect")]public string tagToDetect = "Sphere";
    [Tooltip("Distance to detect your object")]public float maxDistanceDetect = 10f;
    [Tooltip("The Distance Between the surface and your object")]public float ClampOffset = 5;
    public Vector3 BasePosition;

}

[CustomEditor(typeof(SnapToSurface))]
public class Snap2EditorTest : Editor
{
    private void OnSceneGUI()
    {
        var snapE = (SnapToSurface)target;

        if (snapE.UseSnap)
        {
             GameObject targetGameobject = FindClosestSphere(snapE.maxDistanceDetect);
        if (targetGameobject == null )
        {

            return;
        }
         Collider targetCollider = targetGameobject.GetComponent<Collider>();
         Vector3 targetClosestPoint = targetCollider.ClosestPoint(snapE.BasePosition);
         snapE.BasePosition = targetClosestPoint;
        
         Vector3 directionFromSphereToSnapE = snapE.transform.position - targetCollider.transform.position;
         Vector3 offsetClamped = directionFromSphereToSnapE.normalized * snapE.ClampOffset;
         Vector3 offsetSlider;
         Quaternion rotation = Quaternion.FromToRotation(Vector3.up, directionFromSphereToSnapE);
       
         snapE.transform.position = targetClosestPoint + offsetClamped;
         if (snapE.SnapRotation)
         {
             snapE.transform.rotation = rotation;
         }


        
        EditorGUI.BeginChangeCheck();
        snapE.BasePosition = Handles.PositionHandle(snapE.BasePosition, Quaternion.identity);
        Handles.DrawLine(snapE.BasePosition, snapE.transform.position, 1);

        offsetSlider = Handles.Slider((snapE.BasePosition + offsetClamped), directionFromSphereToSnapE, 3, Handles.ArrowHandleCap,0.001f);
        offsetSlider = offsetSlider - snapE.BasePosition;
        snapE.ClampOffset = offsetSlider.magnitude;
        if (EditorGUI.EndChangeCheck())
        {
            //Debug.Log("Test");
            Undo.RecordObject(snapE, "Change Detected");
        }
        
        //Just find sphere if there is multiple
        GameObject FindClosestSphere(float maxdistance)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag(snapE.tagToDetect);
            GameObject closest = null;
            Vector3 position = snapE.transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                //account for radius of sphere as well.
                float curDistance = diff.magnitude; //- go.transform.lossyScale.magnitude;
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

}
