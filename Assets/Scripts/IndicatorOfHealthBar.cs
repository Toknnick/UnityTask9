using UnityEngine;
using UnityEngine.UI;

public class IndicatorOfHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    public void ShowHealthBar(float nowHealth)
    {
        _healthBar.fillAmount = nowHealth;
    }
}
