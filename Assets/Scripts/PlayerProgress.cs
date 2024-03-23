using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{

    public List<PlayerProgressLevel> levels;
    private float _experianceCurrentValue = 0;
    private float _experianceTargetValue = 100;
    private int _LVLValue = 1, maxLvl;
    public RectTransform experianceUI;
    public TextMeshProUGUI LVLValueTMP;

    private void Start()
    {
        SetLevel(_LVLValue);
        DrawUI();
        maxLvl = levels.Count;
    }

    public void AddExperiance(float value)
    {
        if(_LVLValue < maxLvl)
        {
            _experianceCurrentValue += value;
            if(_experianceCurrentValue >= _experianceTargetValue)
            {
                SetLevel(_LVLValue += 1);
                _experianceCurrentValue = 0;
            }
            DrawUI();
        }
    }
    private void SetLevel(int value)
    {
        _LVLValue = value;

        _experianceTargetValue = levels[_LVLValue - 1].experianceForTheNextLevel;
    }
    private void DrawUI()
    {
        experianceUI.anchorMax = new Vector2(_experianceCurrentValue/_experianceTargetValue, 1);
        LVLValueTMP.text = _LVLValue.ToString();
    }

}
