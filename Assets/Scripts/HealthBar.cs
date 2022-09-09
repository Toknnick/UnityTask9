using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private float _nowHealth;
    private float _targetHealth;
    private float _countHealthForChange;
    private int _maxHealth;
    private int _minHealth;

    public void ReduceHealth()
    {
        if (_nowHealth > _minHealth)
            _targetHealth = _nowHealth - _countHealthForChange;
        StartCoroutine(ChangeHealth());
    }

    public void AddHealth()
    {
        if (_nowHealth < _maxHealth)
            _targetHealth = _nowHealth + _countHealthForChange;
        StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        while (_nowHealth < _targetHealth || _nowHealth > _targetHealth)
        {
            _nowHealth = Mathf.MoveTowards(_nowHealth, _targetHealth, Time.deltaTime);
            _healthBar.fillAmount = _nowHealth;
            yield return null;
        }
    }

    private void Start()
    {
        _maxHealth = 1;
        _minHealth = 0;
        _countHealthForChange = 0.1f;
        _nowHealth = 1;
    }
}
