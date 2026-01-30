using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] scarecrowPrefab;
    private GameObject _currentScarecrow;
    public float respawnDelay = 0.2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnScareCrow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void SpawnScareCrow()
    {
        if (_currentScarecrow != null)
        {
            Destroy(_currentScarecrow);
        }
        int index = GameManager.Instance.scareCrowLevel - 1;
        index = Mathf.Clamp(index, 0, scarecrowPrefab.Length - 1);
        
        Instantiate(scarecrowPrefab[index], transform.position, Quaternion.identity);
    }

    public void OnScareCrowDeath()
    {
        StartCoroutine(RespawnRoutine());
    }

    private IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnScareCrow();
    }
}
