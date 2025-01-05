using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;
    [SerializeField] [Range(0, 50)]int poolSize = 5;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        
        for(int i = 0; i < pool.Length; i++)
        {
            // 풀에 적 오브젝트를 생성하여 추가할 수 있습니다.
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false); // 생성된 오브젝트를 비활성화
        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    // Update is called once per frame
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
