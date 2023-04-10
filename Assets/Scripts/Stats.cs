using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private float _percent;
    [SerializeField] private float _maxHealth;

    private const float MaxPercent = 100f;
    private const float MinPercent = 0;

    private float _step;

    public float CurrentHelth { get; private set; }
    public float MinHealth { get; private set; }
    public float MaxHealth => _maxHealth;

    private void OnEnable()
    {
        MinHealth = 0f;
        CurrentHelth = _maxHealth;
        _step = _maxHealth / MaxPercent * _percent;
    }

    private void OnValidate()
    {
        if (_percent > MaxPercent)
        {
            _percent = MaxPercent;
        }
        else if (_percent < MinPercent)
        {
            _percent = MinPercent;
        }

        _step = _maxHealth / MaxPercent * _percent;
    }

    public void DamageOrHeal(bool isDamage)
    {
        if (isDamage)
        {
            CurrentHelth = Mathf.MoveTowards(CurrentHelth, MinHealth, _step);
        }
        else
        {
            CurrentHelth = Mathf.MoveTowards(CurrentHelth, _maxHealth, _step);
        }
    }
}
