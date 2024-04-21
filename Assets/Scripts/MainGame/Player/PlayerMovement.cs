using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 1.0f;
    [SerializeField] private float screenBorder;

    private Rigidbody2D _rigidbody;
    private Vector2 movementInput;
    private Camera _camera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void FixedUpdate() // Instead of using update * delta
    {
        _rigidbody.velocity = movementInput * speed;
        OffScreenWalk();
        RotateInDirectionOfInput();
    }

    private void OnMove(InputValue inputValue)
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

    private void RotateInDirectionOfInput()
    {
        if (movementInput != Vector2.zero) 
        { 
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, movementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }
}
