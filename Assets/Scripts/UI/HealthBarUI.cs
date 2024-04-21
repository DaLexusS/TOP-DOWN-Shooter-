using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image _healthBarUi;
    [SerializeField] private TextMeshProUGUI _healthScore;
    private string maxHealthText = "/100";
    public void UpdateHealthBar(Health healthController)
    {
        _healthScore.text = (healthController.GetHealthPercentage() * 100) + maxHealthText;
        _healthBarUi.fillAmount = healthController.GetHealthPercentage();
    }
}
