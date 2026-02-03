using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Spawn spawner;

    private int _score;
    private int _starLevel = 1;
    [SerializeField] private int starBaseCost = 10;
    [SerializeField] private float starCostMultiplier = 1.8f;
    public int starDamage = 1;

    private int _killCount = 0;
    public int scareCrowLevel = 1;
    [SerializeField] private int scareCrowBaseCost = 100;
    
    private int _specialGauge = 0;
    [SerializeField] public int specialBaseCost = 500;
    
    public float specialTime = 0.05f;
    public int specialCount = 5;
    public bool isSpecialMode = false;
    public float specialDuration = 5f;

    public int currentGold = 0;



    void Awake() => Instance = this;

    public void AddScore(int num)
    {
        _score += num;
        // UIManager.Instance.UpdateScoreUI(_score);
        
        float progress = (float)currentGold / UpgradeManager.Instance.GetStarUpgradeCost(_starLevel, starBaseCost, starCostMultiplier);
        UIManager.Instance.SetGauge(UIManager.Instance.starImage1, UIManager.Instance.starImage2, progress);
        
        AddSpecialGauge();
    }

    public void UpgradeStar()
    {
        int cost = UpgradeManager.Instance.GetStarUpgradeCost(_starLevel, starBaseCost, starCostMultiplier);
        if (currentGold < cost)
        {
            UIManager.Instance.ShowWarning(UIManager.Instance.scoreWarningText);
            return;
        }

        starDamage++;
        currentGold -= cost;
        _starLevel++;
        AddScore(0); 
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        UIManager.Instance.UpdateGoldUI(currentGold);
    }

    public void AddKillCount()
    {
        _killCount++;
        // UIManager.Instance.UpdateKillUI(_killCount);

        float progress = (float)currentGold / scareCrowBaseCost;
        UIManager.Instance.SetGauge(UIManager.Instance.scareCrowImage1, UIManager.Instance.scareCrowImage2, progress);
    }

    public void UpgradeScarecrow()
    {
        scareCrowLevel++;
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
        isSpecialMode = true;
        var progress = (float)_specialGauge / specialBaseCost;

        if (progress < 1f) return;
        
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
