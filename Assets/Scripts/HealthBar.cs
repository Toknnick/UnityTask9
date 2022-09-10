using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    private Coroutine _coroutineChangingHealth;
    private Health _health;

    private void OnEnable() => Health.Changed += ShowBar;

    private void OnDisable() => Health.Changed -= ShowBar;

    private IEnumerator SmoothlyChangeHealth()
    {
        while (_health.Current != _health.TargetHealth)
        {
            _healthBar.fillAmount = _health.Current;
            _health.ChangeHealth(Mathf.MoveTowards(_health.Current, _health.TargetHealth, Time.deltaTime));
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
