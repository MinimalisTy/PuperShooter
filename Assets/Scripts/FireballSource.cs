using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform targetPoint;
    public Camera cameraLink;
    public float TargetInSkyDistance;

    private void Update()
    {
        Aim();  
    }

    private void Aim()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint.position = hit.point;
        }
        else
            targetPoint.position = ray.GetPoint(TargetInSkyDistance);
        transform.LookAt(targetPoint.position);
    }

}
