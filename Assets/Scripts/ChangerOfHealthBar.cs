using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ChangerOfHealthBar : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _indicatorOfHealthBar;
    private float _targetHealth;
    private float _countHealthForChange;
    private float _nowHealth;
    private int _maxHealth;
    private int _minHealth;
    private Coroutine _coroutineChangingHealth;

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
        if (_coroutineChangingHealth != null)
        {
            StopCoroutine(_coroutineChangingHealth);
            _coroutineChangingHealth = StartCoroutine(ChangeHealth());
        }

        while (_nowHealth < _targetHealth || _nowHealth > _targetHealth)
        {
            _indicatorOfHealthBar?.Invoke(_nowHealth);
            _nowHealth = Mathf.MoveTowards(_nowHealth, _targetHealth, Time.deltaTime);
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
