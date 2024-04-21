using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    private Camera _camera;
    private GameObject _player;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        checkBulletOfScreen();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<EnemyMovement>()) // Can use tag enemy instead
        {
            Score score = _player.GetComponent<Score>();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            score.AddScore(15);
        }
    }

    private void checkBulletOfScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 ||
            screenPosition.x > _camera.pixelWidth ||
            screenPosition.y < 0 ||
            screenPosition.y > _camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
