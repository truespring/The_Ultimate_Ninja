using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] scarecrowPrefab;
    private GameObject _currentScarecrow;
    public float respawnDelay = 0.2f;

    void Start()
    {
        SpawnScarecrow();
    }

    public void SpawnScarecrow()
    {
        if (_currentScarecrow != null)
        {
            Destroy(_currentScarecrow);
        }

        int index = GameManager.Instance.scarecrowLevel - 1;
        index = Mathf.Clamp(index, 0, scarecrowPrefab.Length - 1);

        GameObject go = Instantiate(scarecrowPrefab[index], transform.position, Quaternion.identity);
        Scarecrow sc = go.GetComponent<Scarecrow>();
        sc.hp = GameManager.Instance.GetCurrentScarecrowHp();
        _currentScarecrow = go;
    }

    public void OnScarecrowDeath()
    {
        StartCoroutine(RespawnRoutine());
    }

    private IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnScarecrow();
    }
    
    public void Destroy()
    {
        Destroy(_currentScarecrow);
    }
}