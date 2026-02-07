using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    public float speed = 15f;
    public int damage;

    void Start()
    {
        damage = GameManager.Instance.starDamage;
    }

    void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Scarecrow"))
        {
            GameManager.Instance.AddScore();
            collision.GetComponent<Scarecrow>().MinusHp(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
