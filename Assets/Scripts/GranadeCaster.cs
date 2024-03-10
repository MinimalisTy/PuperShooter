using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeCaster : MonoBehaviour
{
    public Rigidbody Granade;
    public Transform GranadeSourceTransform;
    public float force;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            var granade = Instantiate(Granade);
            granade.transform.position = GranadeSourceTransform.position;
            granade.GetComponent<Rigidbody>().AddForce(GranadeSourceTransform.forward * force);
        }
    }


}
