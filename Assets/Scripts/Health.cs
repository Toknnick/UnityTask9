using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Action OnChanged;

    private float _countHealthForChange;
    private int _maxHealth;
    private int _minHealth;

    public float NowHealth { get; private set; }
    public float TargetHealth { get; private set; }

    public void ChangeHealth(float nowHealth)
    {
        NowHealth = nowHealth;
    }

    public void ReduceHealth()
    {
        TargetHealth = NowHealth - _countHealthForChange;

        if (NowHealth > _minHealth)
            OnChanged?.Invoke();
        else
            TargetHealth = 0;
    }

    public void AddHealth()
    {
        TargetHealth = NowHealth + _countHealthForChange;

        if (NowHealth < _maxHealth)
            OnChanged?.Invoke();
        else
            TargetHealth = 1;
    }

    private void Start()
    {
        _maxHealth = 1;
        _minHealth = 0;
        _countHealthForChange = 0.1f;
        NowHealth = 1;
    }
}
