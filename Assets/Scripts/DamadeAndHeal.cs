using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]

public class DamadeAndHeal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthPointsText;
    [SerializeField] private TextMeshProUGUI _healButtonText;
    [SerializeField] private TextMeshProUGUI _damageButtonText;
    [SerializeField] private float _stepChange;

    private float _currentHelth;
    private Slider _healthBar;

    private void OnEnable()
    {
        _healthBar = GetComponent<Slider>();
        _currentHelth = _healthBar.maxValue;
        SetValues();
        _healButtonText.text = $"Вылечить на {_stepChange} очков";
        _damageButtonText.text = $"Навредить на {_stepChange} очков";
    }

    private void OnValidate()
    {
        if (_stepChange > GetComponent<Slider>().maxValue)
        {
            _stepChange = GetComponent<Slider>().maxValue;
        }
        else if (_stepChange < GetComponent<Slider>().minValue)
        {
            _stepChange = GetComponent<Slider>().minValue;
        }
    }

    public void DamageOrHeal(bool isDamage)
    {
        if (isDamage)
        {
            _currentHelth = Mathf.MoveTowards(_currentHelth, _healthBar.minValue, _stepChange);
        }
        else
        {
            _currentHelth = Mathf.MoveTowards(_currentHelth, _healthBar.maxValue, _stepChange);
        }

        SetValues();
    }

    private void SetValues()
    {
        _healthBar.value = _currentHelth;
        _healthPointsText.text = $"{_healthBar.maxValue}/{Mathf.Round(_currentHelth)}";
    }
}
