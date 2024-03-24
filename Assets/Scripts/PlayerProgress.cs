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
    public RectTransform experianceUI, FDlevelBarUI, FireballCostBarUI, FireballFirerateBarUI;
    public TextMeshProUGUI LVLValueTMP;
    public int points = 0;
    private float FireballDamageLVL = 1, FireballCostLVL = 1, FireballFirerateLVL = 1;
    private float GranadeDamageLVL = 1, GranadeRadiusLVL = 1, GranadeCostLVL = 1;
    public TextMeshProUGUI FireballDamageText, FireballCostText, FireballFirerateText;
    public TextMeshProUGUI GranadeDamageText, GranadeRadiusText, GranadeCostText;
    public RectTransform GranadeDamageBarUI, GranadeRadiusBarUI, GranadeCostBarUI;

    private void Start()
    {
        SetLevel(_LVLValue);
        DrawUI();
        maxLvl = levels.Count;
        for(int i = 1; i < levels.Count/3; i++)
        {
            levels[i].UpgradePoints = 2;
        }
        for (int i = levels.Count / 3; i < (levels.Count / 3)*2; i++)
        {
            levels[i].UpgradePoints = 4;
        }
        for (int i = (levels.Count / 3)*2; i < levels.Count; i++)
        {
            levels[i].UpgradePoints = 6;
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
            DrawFireballDamageUI();
        }
        if (levels[(int)FireballDamageLVL].FireballDamageCost != 0)
            FireballDamageText.text = levels[(int)FireballDamageLVL].FireballDamageCost.ToString() + " Points";
        else
            FireballDamageText.text = "Max";
    }
    private void DrawFireballDamageUI()
    {
        FDlevelBarUI.anchorMax = new Vector2(FireballDamageLVL / 10, 1);
    }


    public void FireballCostUpgrade()
    {
        if (points - levels[(int)FireballCostLVL - 1].FireballCasterCostCost >= 0 && FireballCostLVL < 10)
        {
            FireballCostLVL++;
            points -= (int)levels[(int)FireballCostLVL - 1].FireballCasterCostCost;
            GetComponent<FireballCaster>().cost = levels[(int)FireballCostLVL - 1].FireballCasterCost;
            DrawFireballCost();
        }
        if (levels[(int)FireballCostLVL].FireballCasterCostCost != 0)
            FireballCostText.text = levels[(int)FireballCostLVL].FireballCasterCostCost.ToString() + " Points";
        else
            FireballCostText.text = "Max";
    }
    private void DrawFireballCost()
    {
        FireballCostBarUI.anchorMax = new Vector2(FireballCostLVL / 10, 1);
    }

    public void FireballFirerateUpgrade()
    {
        if (points - levels[(int)FireballFirerateLVL - 1].FireballFirerateCost >= 0 && FireballFirerateLVL < 10)
        {
            FireballFirerateLVL++;
            points -= (int)levels[(int)FireballFirerateLVL - 1].FireballFirerateCost;
            GetComponent<FireballCaster>().reloadTime = levels[(int)FireballFirerateLVL - 1].FireballFirerate;
            DrawFireballFirerate();
        }
        if (levels[(int)FireballFirerateLVL].FireballFirerateCost != 0)
            FireballFirerateText.text = levels[(int)FireballFirerateLVL].FireballFirerateCost.ToString() + " Points";
        else
            FireballFirerateText.text = "Max";
    }
    private void DrawFireballFirerate()
    {
        FireballFirerateBarUI.anchorMax = new Vector2(FireballFirerateLVL / 10, 1);
    }

    public void GranadeDamageUpgrade()
    {
        if (points - levels[(int)GranadeDamageLVL - 1].GranadeDamageCost >= 0 && GranadeDamageLVL < 10)
        {
            GranadeDamageLVL++;
            points -= (int)levels[(int)GranadeDamageLVL - 1].GranadeDamageCost;
            GetComponent<GranadeCaster>().damage = levels[(int)GranadeDamageLVL - 1].granadeDamage;
            DrawGranadeDamage();
        }
        if (levels[(int)GranadeDamageLVL].GranadeDamageCost != 0)
            GranadeDamageText.text = levels[(int)GranadeDamageLVL].GranadeDamageCost.ToString() + " Points";
        else
            GranadeDamageText.text = "Max";
    }
    private void DrawGranadeDamage()
    {
        GranadeDamageBarUI.anchorMax = new Vector2(GranadeDamageLVL / 10, 1);
    }

    public void GranadeRadiusUpgrade()
    {
        if (points - levels[(int)GranadeRadiusLVL - 1].GranadeRadiusCost >= 0 && GranadeRadiusLVL < 10)
        {
            GranadeRadiusLVL++;
            points -= (int)levels[(int)GranadeRadiusLVL - 1].GranadeRadiusCost;
            GetComponent<GranadeCaster>().radius = levels[(int)GranadeRadiusLVL - 1].GranadeRadius;
            DrawGranadeRadius();
        }
        if (levels[(int)GranadeRadiusLVL].GranadeRadiusCost != 0)
            GranadeRadiusText.text = levels[(int)GranadeRadiusLVL].GranadeRadiusCost.ToString() + " Points";
        else
            GranadeRadiusText.text = "Max";
    }
    private void DrawGranadeRadius()
    {
        GranadeRadiusBarUI.anchorMax = new Vector2(GranadeRadiusLVL / 10, 1);
    }

    public void GranadeCostUpgrade()
    {
        if (points - levels[(int)GranadeCostLVL - 1].GranadeCostCost >= 0 && GranadeCostLVL < 10)
        {
            GranadeCostLVL++;
            points -= (int)levels[(int)GranadeCostLVL - 1].GranadeCostCost;
            GetComponent<GranadeCaster>().cost = levels[(int)GranadeCostLVL - 1].GranadeCost;
            DrawGranadeCost();
        }
        if (levels[(int)GranadeCostLVL].GranadeCostCost != 0)
            GranadeCostText.text = levels[(int)GranadeCostLVL].GranadeCostCost.ToString() + " Points";
        else
            GranadeCostText.text = "Max";
    }
    private void DrawGranadeCost()
    {
        GranadeCostBarUI.anchorMax = new Vector2(GranadeCostLVL / 10, 1);
    }
}
