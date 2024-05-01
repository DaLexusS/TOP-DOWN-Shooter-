
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyFolder;
    [SerializeField] private GameObject[] zombieSprites;
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    [SerializeField] private float timeUntilNextSpawn;

    private void Awake()
    {
        SetTimeUntilSpawn();    
    }

    private void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;

        if (timeUntilNextSpawn <= 0)
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
}
