using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    public int hp = 100;
    private bool _isDead = false;
    public GameObject goldCoinPrefab;
    

    public void MinusHp(int damage)
    {
        if (_isDead) return;
        
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        _isDead = true;
        GameObject coinObj = Instantiate(goldCoinPrefab, transform.position, Quaternion.identity);
        GoldCoin coinScript = coinObj.GetComponent<GoldCoin>();
        
        // 중요: 코인 스크립트의 변수에 직접 값을 할당해줍니다.
        coinScript.goldAmount = GameManager.Instance.GetCurrentGoldReward(); 
        coinScript.JumpOut();
        
        GameManager.Instance.AddKillCount();
        GameManager.Instance.spawner.OnScarecrowDeath();
        
        Destroy(gameObject);
    }
}
