using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaForCast : MonoBehaviour
{

    public float _staminaValue;
    private float _maxStaminaValue;
    public RectTransform staminaBar;

    private void Start()
    {
        _maxStaminaValue = _staminaValue;
        DrawUI();
    }
    private void Update()
    {

    }

    public void StaminaUpdate1()
    {
        StaminaUpdate(1);
    }

    public void StaminaSpend(float cost)
    {
        _staminaValue -= cost;
        CancelInvoke("StaminaUpdate1");
        
        if (_staminaValue < _maxStaminaValue)
        {
            Invoke("StaminaUpdate1", 3);
        }
        DrawUI();
    }

    public void StaminaUpdate(float fill)
    {
        if (_staminaValue < _maxStaminaValue)
        {
            _staminaValue += fill * Time.deltaTime * 25;
            Invoke("StaminaUpdate1",0.1f);
            Debug.Log("Update");
        }
        else
        {
            Debug.Log("Stop Update");
            CancelInvoke();
        }
        DrawUI();
    }

    private void DrawUI()
    {
        staminaBar.anchorMax = new Vector2(_staminaValue/_maxStaminaValue,1);
    }
}
