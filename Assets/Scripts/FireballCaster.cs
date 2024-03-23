using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public GameObject center;
    public Fireball fireball;
    public StaminaForCast stamina;
    public float cost;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && (stamina._staminaValue - cost) >= 0)
        {
            stamina.StaminaSpend(cost);
            Instantiate(fireball, center.transform.position, center.transform.rotation);
        }
    }
}
