using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Action Changed;

    private float _countHealthForChange;
    private int _maxHealth;
    private int _minHealth;

    public float Current { get; private set; }
    public float TargetHealth { get; private set; }

    public void ChangeHealth(float nowHealth)
    {
        Current = nowHealth;
    }

    public void Damage()
    {
        TargetHealth = Current - _countHealthForChange;

        if (Current > _minHealth)
            Changed?.Invoke();
        else
            TargetHealth = 0;
    }

    public void Heal()
    {
        TargetHealth = Current + _countHealthForChange;

        if (Current < _maxHealth)
            Changed?.Invoke();
        else
            TargetHealth = 1;
    }

    private void Start()
    {
        _maxHealth = 1;
        _minHealth = 0;
        _countHealthForChange = 0.1f;
        Current = 1;
    }
}
