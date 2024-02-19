using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public float x;
    public float MaxAngle, MinAngle;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(gameObject.name == "Player")
        {
            transform.Rotate(0, x * Input.GetAxis("Mouse X"), 0);
        }
        else
        {
            if( transform.localEulerAngles.x <= 40 && transform.localEulerAngles.x >= 0 || transform.localEulerAngles.x <= 45 && transform.localEulerAngles.x >= 40 && Input.GetAxis("Mouse Y") > 0)
            {
               transform.Rotate(x * -Input.GetAxis("Mouse Y"), 0, 0);
            }
            if (transform.localEulerAngles.x >= 310 && transform.localEulerAngles.x <= 360 || transform.localEulerAngles.x >= 305 && transform.localEulerAngles.x <= 310 && Input.GetAxis("Mouse Y") < 0)
            {
                transform.Rotate(x * -Input.GetAxis("Mouse Y"), 0, 0);
            }

        }
        
    }
}
