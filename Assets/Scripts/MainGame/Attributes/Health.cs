using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    public bool isAlive = true;

    public UnityEvent OnDied;
    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damage)
    {

        if (!isAlive)
        {
            return;
        }

        currentHealth = math.max(0, currentHealth - damage);
        OnHealthChanged.Invoke();

        if (currentHealth == 0)
        {
            isAlive = false;
            OnDied.Invoke();
        }
    }

    public void Heal(float heal)
    {
        if (!isAlive)
        {
            return;
        }

        currentHealth = math.min(maxHealth, currentHealth + heal);

        OnHealthChanged.Invoke();
    }

    public float GetHealthPercentage()
    {
        return currentHealth / maxHealth;
    }
}
