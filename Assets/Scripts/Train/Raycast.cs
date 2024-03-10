using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject s;
    public Camera cam;
    private void Update()
    {
        var direction = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(direction,out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                s.transform.position = hit.point;
                Instantiate(s);
            }
            if(Input.GetMouseButtonDown(1))
                Destroy(hit.collider.gameObject);
        }
    }

}
