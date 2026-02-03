using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Sprites")] private SpriteRenderer _spriteRenderer;
    public Sprite[] playerSprites;
    public GameObject ninjaStarPrefab;
    private float frameDelay = 0.1f;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (GameManager.Instance.isSpecialMode)
            {
                StartCoroutine(BurstAttackRoutine());
            }
            else
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        StopCoroutine(ChangeSpriteRoutine());
        Instantiate(ninjaStarPrefab, transform.position, Quaternion.identity);
        StartCoroutine(ChangeSpriteRoutine());
    }

    IEnumerator ChangeSpriteRoutine()
    {
        _spriteRenderer.sprite = playerSprites[1];
        yield return new WaitForSeconds(frameDelay);
        _spriteRenderer.sprite = playerSprites[2];
        yield return new WaitForSeconds(frameDelay);
        _spriteRenderer.sprite = playerSprites[0];
    }

    IEnumerator BurstAttackRoutine()
    {
        for (int i = 0; i < GameManager.Instance.specialCount; i++)
        {
            Attack();
            yield return new WaitForSeconds(GameManager.Instance.specialTime);
        }
    }
}