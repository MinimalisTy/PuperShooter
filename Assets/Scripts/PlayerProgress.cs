using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private float StaminaMaxLVL = 1, StaminaReloadLVL = 1;
    private float PlayerHealthMaxLVL = 1;
    public TextMeshProUGUI FireballDamageText, FireballCostText, FireballFirerateText;
    public TextMeshProUGUI GranadeDamageText, GranadeRadiusText, GranadeCostText;
    public TextMeshProUGUI StaminaMaxText, StaminaReloadText;
    public TextMeshProUGUI PlayerHealthMaxText;
    public RectTransform GranadeDamageBarUI, GranadeRadiusBarUI, GranadeCostBarUI;
    public RectTransform StaminaMaxBarUI, StaminaReloadBarUI;
    public RectTransform PlayerHealthMaxBarUI;
    public List<TextMeshProUGUI> Points;
    public List<GobliSpawn> spawn;

    private void Start()
    {
        SetLevel(_LVLValue);
        DrawUI();
        PointUpdate();
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
                PointUpdate();
            }
            DrawUI();
        }
    }
    private void SetLevel(int value)
    {
        _LVLValue = value;

        _experianceTargetValue = levels[_LVLValue - 1].experianceForTheNextLevel;
        for(int i = 0; i < spawn.Count; i++)
        {
            spawn[i].maxSpeed = levels[_LVLValue - 1].Enemyspeed;
            spawn[i].time = levels[_LVLValue - 1].timeForSpawnEnemy;
            spawn[i].maxHP = levels[_LVLValue - 1].EnemyHPMax;
        }

    }
    private void DrawUI()
    {
        experianceUI.anchorMax = new Vector2(_experianceCurrentValue/_experianceTargetValue, 1);
        LVLValueTMP.text = _LVLValue.ToString();
    }


    private void PointUpdate()  
    {
        for(int i = 0; i < Points.Count; i++)
            Points[i].text = points.ToString();
    }


    public void FireballDamageUpgrade()
    {
        if (points - levels[(int)FireballDamageLVL].FireballDamageCost >= 0 && FireballDamageLVL < 10)
        {
            FireballDamageLVL++;
            points -= levels[(int)FireballDamageLVL-1].FireballDamageCost;
            PointUpdate();
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
        if (points - (int)levels[(int)FireballCostLVL].FireballCasterCostCost >= 0 && FireballCostLVL < 10)
        {
            FireballCostLVL++;
            points -= (int)levels[(int)FireballCostLVL-1].FireballCasterCostCost;
            PointUpdate();
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
        if (points - levels[(int)FireballFirerateLVL].FireballFirerateCost >= 0 && FireballFirerateLVL < 10)
        {
            FireballFirerateLVL++;
            points -= (int)levels[(int)FireballFirerateLVL - 1].FireballFirerateCost;
            PointUpdate();
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
        if (points - levels[(int)GranadeDamageLVL].GranadeDamageCost >= 0 && GranadeDamageLVL < 10)
        {
            GranadeDamageLVL++;
            points -= (int)levels[(int)GranadeDamageLVL - 1].GranadeDamageCost;
            PointUpdate();
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
        if (points - levels[(int)GranadeRadiusLVL].GranadeRadiusCost >= 0 && GranadeRadiusLVL < 10)
        {
            GranadeRadiusLVL++;
            points -= (int)levels[(int)GranadeRadiusLVL - 1].GranadeRadiusCost;
            PointUpdate();
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
        if (points - levels[(int)GranadeCostLVL].GranadeCostCost >= 0 && GranadeCostLVL < 10)
        {
            GranadeCostLVL++;
            points -= (int)levels[(int)GranadeCostLVL - 1].GranadeCostCost;
            PointUpdate();
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


    public void StaminaMaxUpgrade()
    {
        if (points - levels[(int)StaminaMaxLVL].StaminaMaxCost >= 0 && StaminaMaxLVL < 10)
        {
            StaminaMaxLVL++;
            points -= (int)levels[(int)StaminaMaxLVL-1].StaminaMaxCost;
            PointUpdate();
            GetComponent<StaminaForCast>()._maxStaminaValue = levels[(int)StaminaMaxLVL - 1].StaminaMax;
            DrawStaminaMax();
        }
        if (levels[(int)StaminaMaxLVL].StaminaMaxCost != 0)
            StaminaMaxText.text = levels[(int)StaminaMaxLVL].StaminaMaxCost.ToString() + " Points";
        else
            StaminaMaxText.text = "Max";
    }
    private void DrawStaminaMax()
    {
        StaminaMaxBarUI.anchorMax = new Vector2(StaminaMaxLVL / 10, 1);
    }

    public void StaminaReloadUpgrade()
    {
        if (points - levels[(int)StaminaReloadLVL].StaminaReloadCost >= 0 && StaminaReloadLVL < 10)
        {
            StaminaReloadLVL++;
            points -= (int)levels[(int)StaminaReloadLVL-1].StaminaReloadCost;
            PointUpdate();
            GetComponent<StaminaForCast>().reload = levels[(int)StaminaReloadLVL - 1].StaminaReload;
            DrawStaminaReload();
        }
        if (levels[(int)StaminaReloadLVL].StaminaReloadCost != 0)
            StaminaReloadText.text = levels[(int)StaminaReloadLVL].StaminaReloadCost.ToString() + " Points";
        else
            StaminaReloadText.text = "Max";
    }
    private void DrawStaminaReload()
    {
        StaminaReloadBarUI.anchorMax = new Vector2(StaminaReloadLVL / 10, 1);
    }

    public void PlayerHealthMaxUpgrade()
    {
        if (points - levels[(int)PlayerHealthMaxLVL].PlayerHealthMaxCost >= 0 && PlayerHealthMaxLVL < 10)
        {
            PlayerHealthMaxLVL++;
            points -= (int)levels[(int)PlayerHealthMaxLVL-1].PlayerHealthMaxCost;
            PointUpdate();
            GetComponent<PlayerHealth>().hp = (float)levels[(int)PlayerHealthMaxLVL - 1].PlayerHealthMax * ((float)GetComponent<PlayerHealth>().hp/(float)GetComponent<PlayerHealth>().maxhp);
            GetComponent<PlayerHealth>().maxhp = levels[(int)PlayerHealthMaxLVL - 1].PlayerHealthMax;
            GetComponent<PlayerHealth>().DrawHealhBar();
            DrawPlayerHealthMax();
        }
        if (levels[(int)PlayerHealthMaxLVL].PlayerHealthMaxCost != 0)
            PlayerHealthMaxText.text = levels[(int)PlayerHealthMaxLVL].PlayerHealthMaxCost.ToString() + " Points";
        else
            PlayerHealthMaxText.text = "Max";
    }
    private void DrawPlayerHealthMax()
    {
        PlayerHealthMaxBarUI.anchorMax = new Vector2(PlayerHealthMaxLVL / 10, 1);
    }

}
