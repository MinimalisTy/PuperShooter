using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaForCast : MonoBehaviour
{

    public float _staminaValue;
    public float _maxStaminaValue;
    public float reload;
    bool reloadTrue;
    public RectTransform staminaBar;

    private void Start()
    {
        _maxStaminaValue = _staminaValue;
        DrawUI();
    }
    private void Update()
    {
        if(_staminaValue < _maxStaminaValue && reloadTrue == true)
        {
            _staminaValue += reload * Time.deltaTime;
            DrawUI();
        }
    }

    public void StaminaUpdate1()
    {
        reloadTrue = true;
    }

    public void StaminaSpend(float cost)
    {
        reloadTrue = false;
        _staminaValue -= cost;
        CancelInvoke("StaminaUpdate1");
        
        if (_staminaValue < _maxStaminaValue)
        {
            Invoke("StaminaUpdate1", 3);
        }
        DrawUI();
    }


    private void DrawUI()
    {
        staminaBar.anchorMax = new Vector2(_staminaValue/_maxStaminaValue,1);
    }
}
