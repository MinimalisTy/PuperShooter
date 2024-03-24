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
    public RectTransform experianceUI, FDlevelBarUI;
    public TextMeshProUGUI LVLValueTMP;
    public int points = 0;
    private float FireballDamageLVL = 1;
    public TextMeshProUGUI FireballDamageUI;

    private void Start()
    {
        FireballDamageUpgrade();
        SetLevel(_LVLValue);
        DrawUI();
        maxLvl = levels.Count;
        for(int i = 1; i < levels.Count/3; i++)
        {
            levels[i].UpgradePoints = 1;
        }
        for (int i = levels.Count / 3; i < (levels.Count / 3)*2; i++)
        {
            levels[i].UpgradePoints = 2;
        }
        for (int i = (levels.Count / 3)*2; i < levels.Count; i++)
        {
            levels[i].UpgradePoints = 3;
        }
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
                points += levels[_LVLValue - 1].UpgradePoints;
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


    public void FireballDamageUpgrade()
    {
        if (points - levels[(int)FireballDamageLVL - 1].FireballDamageCost >= 0 && FireballDamageLVL < 10)
        {
            FireballDamageLVL++;
            points -= levels[(int)FireballDamageLVL - 1].FireballDamageCost;
            GetComponent<FireballCaster>().damage = levels[(int)FireballDamageLVL - 1].fireballDamage;
            FDlevelBarUI.anchorMax = new Vector2(FireballDamageLVL / 10, 1);
            //FireballDamageUI.text = FireballDamageLVL.ToString() + " Points";
        }
        if (levels[(int)FireballDamageLVL].FireballDamageCost != 0)
            FireballDamageUI.text = levels[(int)FireballDamageLVL].FireballDamageCost.ToString() + " Points";
        else
            FireballDamageUI.text = "Max";
    }


}
