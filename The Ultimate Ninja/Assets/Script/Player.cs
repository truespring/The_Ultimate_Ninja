using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [Header("Sprites")] private SpriteRenderer _spriteRenderer;
    public Sprite idleSprite;
    public Sprite attackSprite;
    public GameObject ninjaStarPrefab;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = idleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
    }

    void Attack()
    {
        StopAllCoroutines();
        Instantiate(ninjaStarPrefab, transform.position, Quaternion.identity);
        StartCoroutine(ChangeSpriteRoutine());
    }

    IEnumerator ChangeSpriteRoutine()
    {
        _spriteRenderer.sprite = attackSprite;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.sprite = idleSprite;
    }
}