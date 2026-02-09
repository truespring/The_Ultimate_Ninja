using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Spawn spawner;

    public int starLevel = 1;
    public int starBaseCost = 10;
    public float starCostMultiplier = 1.12f;
    public int starDamage = 1;

    public int GetCurrentStartIndex(int maxIndex) => Mathf.Clamp(starLevel - 1, 0, maxIndex);

    public int scarecrowLevel = 1;
    public int scareCrowBaseCost = 100;
    public float scareCrowCostMultiplier = 1.15f;

    public int GetCurrentScarecrowHp() => 100 + ((scarecrowLevel - 1) * 50);
    public int GetCurrentGoldReward() => 1 + ((scarecrowLevel - 1) * 2);

    private int _specialGauge = 0;
    public int specialBaseCost = 500;

    public float specialTime = 0.05f;
    public int specialCount = 5;
    public bool isSpecialMode = false;
    public float specialDuration = 5f;

    public int currentGold = 0;

    void Awake() => Instance = this;

    public void AddScore()
    {
        float progress = (float)currentGold /
                         UpgradeManager.Instance.GetUpgradeCost(starLevel, starBaseCost, starCostMultiplier);
        UIManager.Instance.SetGauge(UIManager.Instance.starImage1, UIManager.Instance.starImage2, progress);

        AddSpecialGauge();
    }

    public void UpgradeStar()
    {
        int cost = UpgradeManager.Instance.GetUpgradeCost(starLevel, starBaseCost, starCostMultiplier);
        if (currentGold < cost)
        {
            UIManager.Instance.ShowWarning(UIManager.Instance.scoreWarningText);
            return;
        }

        // SoundManager.Instance.SoundUpgradeNinjaStar();
        starDamage++;
        currentGold -= cost;
        starLevel++;
        AddScore();
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        UIManager.Instance.UpdateGoldUI(currentGold);
    }

    public void AddKillCount()
    {
        float progress = (float)currentGold / scareCrowBaseCost;
        UIManager.Instance.SetGauge(UIManager.Instance.scareCrowImage1, UIManager.Instance.scareCrowImage2, progress);
    }

    public void UpgradeScarecrow()
    {
        int cost = UpgradeManager.Instance.GetUpgradeCost(scarecrowLevel, scareCrowBaseCost, scareCrowCostMultiplier);
        if (currentGold < cost)
        {
            UIManager.Instance.ShowWarning(UIManager.Instance.killWarningText);
            return;
        }

        // SoundManager.Instance.SoundUpgradeScarecrow();
        scarecrowLevel++;
        spawner.Destroy();
        spawner.SpawnScarecrow();
        currentGold -= scareCrowBaseCost;
        AddKillCount();
    }

    private void AddSpecialGauge()
    {
        _specialGauge++;
        var progress = (float)_specialGauge / specialBaseCost;
        UIManager.Instance.SetSpecialGauge(progress);

        if (progress >= 1f)
        {
            UIManager.Instance.specialText.GetComponent<TMPColor>().OnActivate();
        }
    }

    public void UseSpecial()
    {
        var progress = (float)_specialGauge / specialBaseCost;

        if (progress < 1f) return;

        // SoundManager.Instance.SoundSpecial();
        isSpecialMode = true;
        _specialGauge = 0;
        UIManager.Instance.SetSpecialGauge(_specialGauge);
        UIManager.Instance.specialText.GetComponent<TMPColor>().StopTrigger();

        StartCoroutine(SpecialModeTimer());
    }

    private IEnumerator SpecialModeTimer()
    {
        yield return new WaitForSeconds(specialDuration);
        isSpecialMode = false;
    }
}