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
    [SerializeField] public string weaponType = "Pistol";
    [SerializeField] private ParticleSystem shotParticles = default;
    [SerializeField] Camera cam;
    

    private float lastShot;
    private bool fireContinously;
    private bool fireSingle;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = cam.GetComponent<AudioManager>();
    }

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
        audioManager.PlaySound(weaponType);
        shotParticles.transform.position = gunOffset.position;
        shotParticles.Play();
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
