using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float screenBorder;

    private Rigidbody2D _rigidbody;
    private PlayerDetection playerDetection;
    private Vector2 targetDirection;
    private float directionChangeCooldown;
    private Camera _camera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        playerDetection = GetComponent<PlayerDetection>();
        targetDirection = transform.up;
        _camera = Camera.main;
        SetRandomSpeed();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        SetRandomDirection();
        PlayerTargetingCheck();
        EnenmyOffScreenCheck();
    }

    private void SetRandomDirection()
    {
        directionChangeCooldown -= Time.deltaTime;
        if (directionChangeCooldown <= 0)
        {
            float angleChange = UnityEngine.Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            directionChangeCooldown = UnityEngine.Random.Range(1f, 5f);
        }
    }

    private void PlayerTargetingCheck()
    {
        if (playerDetection.playerDetected)
        {
            targetDirection = playerDetection.DirectionToPlayer;
        }
    }

    private void EnenmyOffScreenCheck()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < screenBorder && targetDirection.x < 0 ||
            screenPosition.x > _camera.pixelWidth - screenBorder && targetDirection.x > 0)
        {
            targetDirection = new Vector2(-targetDirection.x, targetDirection.y);
        }

        if (screenPosition.y < screenBorder && targetDirection.y < 0 ||
            screenPosition.y > _camera.pixelHeight - screenBorder && targetDirection.y > 0)
        {
            targetDirection = new Vector2(targetDirection.x, -targetDirection.y);
        }
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetRandomSpeed()
    {
        speed = Random.Range(1, 3);
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = transform.up * speed;
    }

}
