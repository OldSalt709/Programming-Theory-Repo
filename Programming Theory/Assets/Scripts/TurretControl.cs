using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    // This script allows the user to rotate the turret,
    // and raise and lower the barrel elevation.
    public Transform barrel;
    public float min = -30;
    public float max = 30;
    private float rotateSpeed = 30.0f;

    float elevation = 0;

    void Update()
    {
        // horizontal rotation control
        transform.Rotate(0, RotateYAxis(), 0);

        // barrel elevation control
        float v = RotateXAxis();
        elevation = Mathf.Clamp(elevation+v,min,max);
        barrel.localRotation = Quaternion.Euler(elevation,0,0);
    }

    float RotateYAxis()
    {
        return Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
    }

    float RotateXAxis()
    {
        return Input.GetAxis("Vertical") * rotateSpeed * Time.deltaTime;
    }
}