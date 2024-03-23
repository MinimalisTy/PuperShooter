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
            granade.transform.position = GranadeSourceTransform.position;
            granade.GetComponent<Rigidbody>().AddForce(GranadeSourceTransform.forward * force);
        }
    }


}
