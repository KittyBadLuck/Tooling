using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TestSnap : MonoBehaviour
{
    public float maxDistanceDetect = 10f;
    //public float maxDistanceSnap = 1f;
    public bool useCustomHandle;
    public bool useSnap;
    public bool useClampOffset;
    public float ClampOffset = 5;
    public Vector3 testOffset;


}

[CustomEditor(typeof(TestSnap))]
public class SnapEditorTest : Editor
{
    private void OnSceneGUI()
    {
        //Debug.Log("Test");
        //Original part
        var snapE = (TestSnap)target;

        Collider myCollider = snapE.GetComponent<Collider>();
        Vector3 position = snapE.transform.position;
        Quaternion rotation = snapE.transform.rotation;

        float maxdistance = snapE.maxDistanceDetect;
        GameObject targetGameobject = FindClosestSphere(maxdistance);
        if (targetGameobject == null )
        {
            return;
        }
        Collider targetCollider = targetGameobject.GetComponent<Collider>();
        
        Vector3 targetClosestPoint;
        Vector3 offset;
        
        targetClosestPoint = targetCollider.ClosestPoint(snapE.transform.position);
        offset = snapE.transform.position - targetClosestPoint;
        Vector3 normalOfSphere = Vector3.Normalize(offset);
        Quaternion normalOfSphereQuat = Quaternion.Euler(normalOfSphere);
        //offset = snapE.transform.InverseTransformDirection(offset);
        if (snapE.useClampOffset)
        { 
            offset = new Vector3(Mathf.Clamp(offset.x, 0, 0), Mathf.Clamp(offset.y, snapE.ClampOffset, snapE.ClampOffset), Mathf.Clamp(offset.z,0,0));
        }
        else
        {
            offset = new Vector3(Mathf.Clamp(offset.x, 0, 0), offset.y, Mathf.Clamp(offset.z,0,0));
        }
        snapE.testOffset = offset;



            //Vector3 offsetTest = targetClosestPoint - MyClosestPoint;
        
       EditorGUI.BeginChangeCheck();
       

        if (snapE.useCustomHandle)
        {
            //Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, snapE.transform.position);
            Quaternion quaternion = Quaternion.identity;
            position = Handles.PositionHandle(targetClosestPoint, quaternion) ;
            rotation = Handles.RotationHandle(quaternion,targetClosestPoint);
            
            if (  snapE.useSnap == true)
            {
                snapE.transform.rotation = rotation;
               snapE.transform.position = position + (normalOfSphereQuat * offset);
            }
        }
        
        
        if (EditorGUI.EndChangeCheck())
        {
            Debug.Log("Change");
            Undo.RecordObject(snapE, "Change Detected");
        }
        
        //Just find sphere if there is multiple
        GameObject FindClosestSphere(float maxdistance)
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Sphere");
            GameObject closest = null;
            float distance = maxdistance;
            Vector3 position = snapE.transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
            
        }
        
    }

}

