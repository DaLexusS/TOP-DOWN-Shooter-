using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] GameObject CollectablePrefab;
    [SerializeField] int itemLimit;
    [SerializeField] public float spawnChance = 0f;
    public Camera mainCamera;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 10f;
    

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            float randomChance = Random.value;

            if (randomChance <= spawnChance)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), 10);
                Vector3 worldSpawnPosition = mainCamera.ScreenToWorldPoint(spawnPosition);

                if (CheckItemCount() < itemLimit)
                {
                    Instantiate(CollectablePrefab, worldSpawnPosition, Quaternion.identity, gameObject.transform);
                }
            }

            nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
        }
    }

    int CheckItemCount()
    {
        int itemCount = 0;
        HealthBox[] healthBoxes = FindObjectsOfType<HealthBox>();

        foreach (HealthBox box in healthBoxes)
        {
            if (box.gameObject.activeSelf)
            {
                itemCount++;
            }
        }

        return itemCount;
    }
}
