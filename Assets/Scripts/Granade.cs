using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{

    public float delay;
    public GameObject ExplosionPrefab;


    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }


    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = transform.position;
    }

}
