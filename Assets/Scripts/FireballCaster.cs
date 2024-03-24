using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public GameObject center;
    public Fireball fireball;
    public StaminaForCast stamina;
    public float cost;
    public float damage;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && (stamina._staminaValue - cost) >= 0)
        {
            stamina.StaminaSpend(cost);
            var Fireball = Instantiate(fireball, center.transform.position, center.transform.rotation);
            Fireball.GetComponent<Fireball>().damage = damage;
        }
    }
}
