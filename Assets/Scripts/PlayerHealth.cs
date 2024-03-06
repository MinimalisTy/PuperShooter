using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float hp;
    private float maxhp = 100;
    public RectTransform valueRectTransform;
    public GameObject GameplayUI;
    public GameObject GameOverUI, camera;
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


    private void DrawHealhBar()
    {
        valueRectTransform.anchorMax = new Vector2(hp/maxhp, 1);
    }

    private void PlayersDead()
    {
        GameplayUI.SetActive(false);
        GameOverUI.SetActive(true);
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        camera.GetComponent<CameraRotation>().enabled = false;
    }


}
