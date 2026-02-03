using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [Header("Text")]
    public Text scoreText;
    public Text killText;
    public Text scoreWarningText;
    public Text killWarningText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI specialText;
    
    [Header("Gauges")]
    public Image starImage1; public Image starImage2;
    public Image scareCrowImage1; public Image scareCrowImage2;
    public Image specialGaugeImage;
    
    void Awake() => Instance = this;
    
    public void UpdateGoldUI(int money) => moneyText.text = "금전: " + money;
    // public void UpdateScoreUI(int score) => scoreText.text = "점수: " + score;
    // public void UpdateKillUI(int kill) => killText.text = "허수아비: " + kill;

    public void ShowWarning(Text warningText)
    {
        warningText.gameObject.SetActive(true);
        StartCoroutine(HideWarningAfterDelay(warningText, 1.5f));
    }

    private IEnumerator HideWarningAfterDelay(Text warningText, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        warningText.gameObject.SetActive(false);
    }

    public void SetGauge(Image img1, Image img2, float progress)
    {
        img1.fillAmount = Mathf.Clamp01(progress * 2f);
        img2.fillAmount = progress > 0.5f ? Mathf.Clamp01((progress - 0.5f) * 2f) : 0;
    }
    
    public void SetSpecialGauge(float progress) => specialGaugeImage.fillAmount = progress;
}
