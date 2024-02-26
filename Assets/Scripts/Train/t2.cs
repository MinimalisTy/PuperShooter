using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t2 : MonoBehaviour
{
    public float value;
    private void Update()
    {
        gameObject.transform.position = new Vector3 (value * 100, 0, 0);
        if(value!=0)
            gameObject.transform.localScale = new Vector3(value * 30, value*30, (1/value)*30);

    }
}
