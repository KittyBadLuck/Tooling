using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3_E0 : MonoBehaviour
{
    //public Camera camera;

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 end = Camera.main.transform.position;
        Color color = Color.green;
        
        Debug.DrawLine(origin, end, color);
    }
}
