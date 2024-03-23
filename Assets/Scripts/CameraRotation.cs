using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform Camera;
    public float x;
    public float MaxAngle, MinAngle;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * Input.GetAxis("Mouse X") * x;
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);

        var newAngleX = Camera.localEulerAngles.x - Time.deltaTime * x * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
            newAngleX -= 360;

        newAngleX= Mathf.Clamp(newAngleX, MinAngle, MaxAngle);

        Camera.localEulerAngles = new Vector3(newAngleX, 0, 0);
        
    }
}
