using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_E0 : MonoBehaviour
{
    public Vector2 mousePosition;
    public float mouseHorizontalPosition;
    public float mouseVerticalPosition;

    private void Update()
    {
       Vector3 mousePosition3d = UnityEngine.Input.mousePosition;
       mousePosition = mousePosition3d;
       mouseHorizontalPosition = mousePosition.x;
       mouseVerticalPosition = mousePosition.y;
    }
}
