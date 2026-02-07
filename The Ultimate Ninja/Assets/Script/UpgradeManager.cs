using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;
    void Awake() => Instance = this;

    public int GetUpgradeCost(int level, int baseCost, float multiplier)
    {
        if (level <= 1) return baseCost;
        return Mathf.RoundToInt(baseCost * Mathf.Pow(multiplier, level - 1));
    }
}
