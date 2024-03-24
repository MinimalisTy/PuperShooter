using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public GameObject center;
    public Fireball fireball;
    public StaminaForCast stamina;
    public float cost;
    public float damage;
    private float reload;
    public float reloadTime = 1.5f;
    public RectTransform Reload;
    public GameObject ReloadBar;
    private bool fast, ready;
    private void Update()
    {

        if (reloadTime > 0.5f)
        {
            fast = false;
        }
        else
            fast = true;


        if (fast == false)
            slowShoot();
        if (fast == true)
            fastShoot();


        if (reload > 0)
        {
            reload -= Time.deltaTime;
            Reloading();
        }
        else
            ReloadBar.SetActive(false);
        
    }

    private void Reloading()
    {
        Reload.anchorMax = new Vector2((reloadTime - reload)/ reloadTime, 1);
    }

    private void slowShoot()
    {
        if ((Input.GetMouseButtonDown(0) && (stamina._staminaValue - cost) >= 0 && reload <= 0))
        {
            stamina.StaminaSpend(cost);
            CreatFireball();
            reload = reloadTime;
            ReloadBar.SetActive(true);
        }

    }

    private void fastShoot()
    {
        if (Input.GetMouseButtonDown(0))
            ready = true;
        else if (Input.GetMouseButtonUp(0))
            ready = false;
        if(ready == true && (stamina._staminaValue - cost) >= 0)
        {
            if(reload <= 0)
            {
                stamina.StaminaSpend(cost);
                CreatFireball();
                reload = reloadTime;
                ReloadBar.SetActive(true);
            }
        }

    }

    private void CreatFireball()
    {
        var Fireball = Instantiate(fireball, center.transform.position, center.transform.rotation);
        Fireball.GetComponent<Fireball>().damage = damage;
    }
}
