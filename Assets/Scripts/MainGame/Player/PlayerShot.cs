using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform gunOffset;
    [SerializeField] private float shotCoolDown;
    [SerializeField] private GameObject projectileFolder;
    [SerializeField] private GameObject player;

    private float lastShot;
    private bool fireContinously;
    private bool fireSingle;

    void Update()
    {
        if (fireContinously || fireSingle)
        {
            float timeSinceLastShot = Time.time - lastShot;

            if (timeSinceLastShot >= shotCoolDown)
            {
                FireBullet();

                lastShot = Time.time;
                fireSingle = false;
            }
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunOffset.position, transform.rotation, projectileFolder.transform);
        Rigidbody2D _rigidbody = bullet.GetComponent<Rigidbody2D>();

        _rigidbody.velocity = bulletSpeed * transform.up;
    }
    private void OnFire(InputValue inputValue)
    {
        fireContinously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            fireSingle = true;
        }
    }
}
