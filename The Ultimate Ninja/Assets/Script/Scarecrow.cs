using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    public int hp = 100;
    private bool _isDead = false;
    

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
        GameManager.Instance.AddKillCount();
        GameManager.Instance.spawner.OnScareCrowDeath();
        Destroy(gameObject);
    }
}
