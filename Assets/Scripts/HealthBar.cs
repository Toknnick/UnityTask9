using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    private Coroutine _coroutineChangingHealth;
    private Health _health;
    private float _current;
    private float _targetHealth;

    private void OnEnable() => Health.Changed += ShowBar;

    private void OnDisable() => Health.Changed -= ShowBar;

    private IEnumerator SmoothlyChangeHealth()
    {
        while (_current != _targetHealth)
        {
            _healthBar.fillAmount = _current;
            _current = Mathf.MoveTowards(_current, _targetHealth, Time.deltaTime);
            yield return null;
        }

        _health.Change(_current);
    }

    private void ShowBar(float countHealthForChange, float current)
    {
        _current = current;
        _targetHealth = current + countHealthForChange;

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

    private void Start()
    {
        _health = GetComponent<Health>();
    }

}
