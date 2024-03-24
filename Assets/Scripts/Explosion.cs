using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxSize = 8;
    public float damage;
    private void Start()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        gameObject.transform.localScale += Vector3.one * Time.deltaTime * 30;
        if(transform.localScale.x >= maxSize)
            Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        var PlayerHP = other.GetComponent<PlayerHealth>();
        if(PlayerHP != null )
        {
            PlayerHP.DealDamage(damage);
        }
        var EnemyHP = other.GetComponent<EnemyHP>();
        if(EnemyHP != null )
        {
            EnemyHP.DealDamage(damage);
        }
    }

}
