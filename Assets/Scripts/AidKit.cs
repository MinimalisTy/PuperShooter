using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{

    public float healAmount = 50;


    private void OnTriggerEnter(Collider other)
    {
        var health = other.gameObject.GetComponent<PlayerHealth>();
        if(health != null)
        {
            Destroy(gameObject);
            health.AddHealth(healAmount);
        }
    }

}
