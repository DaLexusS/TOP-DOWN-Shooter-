
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyFolder;
    [SerializeField] private GameObject[] zombieSprites;
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    [SerializeField] private float timeUntilNextSpawn;
    [SerializeField] int enemyLimit;

    private void Awake()
    {
        SetTimeUntilSpawn();    
    }

    private void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;

        if (timeUntilNextSpawn <= 0 && CheckEnemyCount() < enemyLimit)
        {
            GameObject selectedZombie = GetRandomSprite();
            Instantiate(selectedZombie, transform.position, Quaternion.identity, enemyFolder.transform);

            SetTimeUntilSpawn();
        }
    }

    private GameObject GetRandomSprite()
    {
        return zombieSprites[Random.Range(0, zombieSprites.Length)];
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilNextSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }

    private int CheckEnemyCount()
    {
        int enemyCount = 0;
        EnemyAttack[] enemies = enemyFolder.GetComponentsInChildren<EnemyAttack>();

        foreach (EnemyAttack enemy in enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                enemyCount++;
            }
        }

        return enemyCount;
    }
}
