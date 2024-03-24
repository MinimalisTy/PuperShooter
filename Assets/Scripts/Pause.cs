using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    int paused = 0;
    public GameObject Menu, UI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == 0)
            {
                Paused();
            }
            else if(paused == 1)
            {
                UnPaused();
            }
        }
    }


    private void Paused()
    {
        GetComponent<CameraRotation>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        Menu.SetActive(true);
        UI.SetActive(false);
        paused = 1;
    }

    public void UnPaused()
    {
        GetComponent<CameraRotation>().enabled = true;
        GetComponent<PlayerController>().enabled = true;
        GetComponent<FireballCaster>().enabled= true;
        Time.timeScale = 1;
        Menu.SetActive(false);
        UI.SetActive(true);
        paused = 0;
    }

}
