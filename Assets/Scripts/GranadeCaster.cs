using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeCaster : MonoBehaviour
{
    public Rigidbody Granade;
    public Transform GranadeSourceTransform;
    public float force;
    private StaminaForCast stamina;
    public float cost;
    public float damage;
    public float radius;
    private void Start()
    {
        stamina = FindObjectOfType<StaminaForCast>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && stamina._staminaValue - cost >= 0)
        {
            stamina.StaminaSpend(cost);
            var granade = Instantiate(Granade);
            granade.GetComponent<Granade>().ExplosionPrefab.GetComponent<Explosion>().damage = damage;
            granade.GetComponent<Granade>().ExplosionPrefab.GetComponent<Explosion>().maxSize = radius;
            granade.transform.position = GranadeSourceTransform.position;
            granade.GetComponent<Rigidbody>().AddForce(GranadeSourceTransform.forward * force);
        }
    }


}
