using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    private Coroutine _coroutineChangingHealth;
    private Health _health;

    private void OnEnable() => Health.OnChanged += ShowBar;

    private void OnDisable() => Health.OnChanged -= ShowBar;

    private IEnumerator SmoothlyChangeHealth()
    {

        while (_health.NowHealth < _health.TargetHealth || _health.NowHealth > _health.TargetHealth)
        {
            _healthBar.fillAmount = _health.NowHealth;
            _health.ChangeHealth(Mathf.MoveTowards(_health.NowHealth, _health.TargetHealth, Time.deltaTime));
            yield return null;
        }
    }

    private void ShowBar()
    {
        if (_coroutineChangingHealth != null)
        {
            StopCoroutine(_coroutineChangingHealth);
            _coroutineChangingHealth = StartCoroutine(SmoothlyChangeHealth());
        }
        else
        {
            _coroutineChangingHealth = StartCoroutine(SmoothlyChangeHealth());
        }
    }

    private void Start() => _health = GetComponent<Health>();
}
