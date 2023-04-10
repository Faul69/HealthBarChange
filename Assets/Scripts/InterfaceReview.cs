using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Stats))]

public class InterfaceReview : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthPointsText;
    [SerializeField] private TextMeshProUGUI _healButtonText;
    [SerializeField] private TextMeshProUGUI _damageButtonText;
    [SerializeField] private float _percentInSecond;

    private const float MaxPercent = 100f;

    private Slider _slider;
    private Stats _stats;
    private float _deltaFill;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _stats = GetComponent<Stats>();
        _slider.maxValue = _stats.MaxHealth;
        _slider.minValue = _stats.MinHealth;
        _slider.value = _slider.maxValue;
        _deltaFill = _slider.maxValue / MaxPercent * _percentInSecond * Time.fixedDeltaTime;
        _healButtonText.text = $"��������";
        _damageButtonText.text = $"���������";
    }

    private void FixedUpdate()
    {
        if (_slider.value != _stats.CurrentHelth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _stats.CurrentHelth, _deltaFill);
            _healthPointsText.text = $"{_stats.MaxHealth}/{Mathf.Round(_slider.value)}";
        }
    }

    private void OnValidate()
    {
        float minPercent = 0;
        _percentInSecond = Mathf.Clamp(_percentInSecond, minPercent, MaxPercent);
    }
}