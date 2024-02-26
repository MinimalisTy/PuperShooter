using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public GameObject center;
    public Fireball fireball;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(fireball, center.transform.position, center.transform.rotation);
        }
    }
}
