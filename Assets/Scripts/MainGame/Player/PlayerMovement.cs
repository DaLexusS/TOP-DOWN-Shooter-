using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float screenBorder;

    private Rigidbody2D _rigidbody;
    private Vector2 movementInput;
    private Camera _camera;
    private Health _health;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _camera = Camera.main;
    }

    private void FixedUpdate() // Instead of using update * delta
    {
        if (!_health.isAlive)
        {
            return;
        }
        _rigidbody.velocity = movementInput * speed;
        OffScreenWalk();
        RotateInDirectionOfMouse();
    }

    private void OnMove(InputValue inputValue) // It is being called form input package!!!
    {
        movementInput = inputValue.Get<Vector2>(); // Gets vector of the pressed keys even if it's both a/w
    }

    private void OffScreenWalk()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < screenBorder && _rigidbody.velocity.x < 0 || 
            screenPosition.x > _camera.pixelWidth - screenBorder && _rigidbody.velocity.x > 0) //I spent way to much time making it work
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if (screenPosition.y < screenBorder && _rigidbody.velocity.y < 0 || 
            screenPosition.y > _camera.pixelHeight - screenBorder && _rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }
    }
    private void RotateInDirectionOfMouse()
    {
        var mouse_pos = Input.mousePosition;
        var object_pos = Camera.main.WorldToScreenPoint(_rigidbody.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
