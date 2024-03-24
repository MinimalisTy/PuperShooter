using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float lifeTime;
    public float damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Contains("Fireball"))
            DestroyObject();
    }


    private void Start()
    {
        Invoke("DestroyObject", lifeTime);
    }


    void FixedUpdate()
    {
        FixedMoveFireBall();
    }

    private void FixedMoveFireBall()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
