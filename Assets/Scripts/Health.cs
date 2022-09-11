using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Action<float, float> Changed;

    private float _countHealthForChange;
    private int _maxHealth;
    private int _minHealth;
    private float _current;

    public void Change(float nowHealth)
    {
        _current = nowHealth;
    }

    public void Damage()
    {
        if (_current  <= _minHealth)
            _current = 0;

        Changed?.Invoke(-_countHealthForChange, _current);
    }

    public void Heal()
    {
        if (_current  >= _maxHealth)
            _current = 1;

        Changed?.Invoke(_countHealthForChange, _current);
    }

    private void Start()
    {
        _maxHealth = 1;
        _minHealth = 0;
        _countHealthForChange = 0.1f;
        _current = 1;
    }
}
