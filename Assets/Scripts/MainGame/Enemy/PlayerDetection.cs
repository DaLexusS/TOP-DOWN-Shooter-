using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool playerDetected { get; private set; }
    
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField] private float playerDistance;
    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerDistance )
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }
}
