using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthPointsText;
    [SerializeField] private TextMeshProUGUI _healButtonText;
    [SerializeField] private TextMeshProUGUI _damageButtonText;
    [SerializeField] private float _percent;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;

    private const float MaxPercent = 100f;
    private const float MinPercent = 0;

    private float _step;

    public float CurrentHelth { get; private set; }
    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;

    private void OnEnable()
    {
        CurrentHelth = _maxHealth;
        _step = _maxHealth / MaxPercent * _percent;
        ShowInfo();
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
            CurrentHelth = Mathf.MoveTowards(CurrentHelth, _minHealth, _step);
        }
        else
        {
            CurrentHelth = Mathf.MoveTowards(CurrentHelth, _maxHealth, _step);
        }

        ShowInfo();
    }

    private void ShowInfo()
    {
        _healthPointsText.text = $"{_maxHealth}/{Mathf.Round(CurrentHelth)}";
        _healButtonText.text = $"Вылечить на {_percent}%";
        _damageButtonText.text = $"Навредить на {_percent}%";
    }
}
