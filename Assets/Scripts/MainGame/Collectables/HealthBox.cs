using UnityEngine;

public class HealthBox : MonoBehaviour
{
    [SerializeField] int healthAmount = 20;
    [SerializeField] GameObject Player;
    private bool canHeal = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && canHeal)
        {
            canHeal = false;
            collision.gameObject.GetComponent<Health>().Heal(healthAmount);
            Destroy(gameObject);
        }
    }
}
