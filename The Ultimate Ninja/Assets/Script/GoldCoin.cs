using TMPro;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    private Rigidbody2D _rb;

    public int goldAmount = 1;
    private TextMeshProUGUI _textMeshProUGUI;
    
    private readonly float _collectDelay = 0.7f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void JumpOut()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        UIManager.Instance.UpdateCoinAmount(_textMeshProUGUI, goldAmount);
        _rb.AddForce(new Vector2(0, 2f), ForceMode2D.Impulse);

        Invoke("StartCollect", _collectDelay);
    }

    void StartCollect()
    {
        GameManager.Instance.AddGold(goldAmount);
        Destroy(gameObject);
    }
}