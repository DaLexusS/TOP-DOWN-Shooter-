using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool playerDetected { get; private set; }
    
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField] private float playerDetectionDistance;
    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        SetRandomSpeed();
    }
    
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerDetectionDistance)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }

    private void SetRandomSpeed()
    {
        playerDetectionDistance = Random.Range(5, 8);
    }
}
