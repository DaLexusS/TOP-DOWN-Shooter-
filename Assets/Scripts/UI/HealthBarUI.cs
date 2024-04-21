using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image _healthBarUi;

    public void UpdateHealthBar(Health healthController)
    {
        _healthBarUi.fillAmount = healthController.GetHealthPercentage();
    }
}
