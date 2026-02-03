using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool isCollecting = false;
    public int goldAmount = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void JumpOut()
    {
        rb.AddForce(new Vector2(0, 2f), ForceMode2D.Impulse);

        Invoke("StartCollect", 0.4f);
    }

    void StartCollect()
    {
        GameManager.Instance.AddGold(goldAmount);
        Destroy(gameObject);
    }
}