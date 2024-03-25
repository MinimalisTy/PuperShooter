using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float hp;
    public float maxhp = 100;
    public RectTransform valueRectTransform;
    public GameObject GameplayUI;
    public GameObject GameOverUI, camera;
    public Animator anim, player;

    private void Start()
    {
        hp = maxhp;
    }

    public void DealDamage(float damage)
    {
        hp -= damage;
        valueRectTransform.anchorMax = new Vector2(hp / maxhp, 1);
        if (hp <= 0)
        {
            PlayersDead();
        }

        DrawHealhBar();
    }


    public void AddHealth(float amount)
    {
        hp += amount;
        hp = Mathf.Clamp(hp, 0, maxhp);
        DrawHealhBar();
    }

    public void DrawHealhBar()
    {
        valueRectTransform.anchorMax = new Vector2(hp/maxhp, 1);
    }

    private void PlayersDead()
    {
        player.SetInteger("Dead", 1);
        anim.gameObject.GetComponent<Animator>().enabled = true;
        anim.SetBool("GameOver", true);
        Time.timeScale = 0.25f;
        GetComponent<Pause>().enabled = false;
        GameplayUI.SetActive(false);
        GameOverUI.SetActive(true);
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        camera.GetComponent<CameraRotation>().enabled = false;
    }


}
