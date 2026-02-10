using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("Sprites")] private SpriteRenderer _spriteRenderer;
    public Sprite[] playerSprites;
    public GameObject[] ninjaStarPrefab;
    private readonly float _frameDelay = 0.1f;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            OnFire();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            OnFire();
        }
    }

    void OnFire()
    {
        SoundManager.Instance.SoundShoot();
        if (GameManager.Instance.isSpecialMode)
        {
            StartCoroutine(BurstAttackRoutine());
        }
        else
        {
            Attack();
        }
    }

    void Attack()
    {
        StopCoroutine(ChangeSpriteRoutine());
        Instantiate(ninjaStarPrefab[GameManager.Instance.GetCurrentStartIndex(ninjaStarPrefab.Length)], transform.position,
            Quaternion.identity);
        StartCoroutine(ChangeSpriteRoutine());
    }

    IEnumerator ChangeSpriteRoutine()
    {
        _spriteRenderer.sprite = playerSprites[1];
        yield return new WaitForSeconds(_frameDelay);
        _spriteRenderer.sprite = playerSprites[2];
        yield return new WaitForSeconds(_frameDelay);
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