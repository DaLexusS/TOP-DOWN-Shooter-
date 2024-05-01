using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float attackCooldown;
    private float timeCheck;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Time.time >= timeCheck)
        {
            var healthController = collision.gameObject.GetComponent<Health>();
            var scoreScript = collision.gameObject.GetComponent<Score>();
            if (healthController != null && scoreScript != null)
            {
                healthController.TakeDamage(Mathf.Floor(damage * scoreScript.difficultyMultiplier));
            }

            timeCheck = Time.time + attackCooldown;
        }
    }

}
