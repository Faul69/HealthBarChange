using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Health))]

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthPointsText;
    [SerializeField] private float _percentInSecond;

    private const float MaxPercent = 100f;

    private Coroutine _routine;
    private WaitForSeconds _wait;
    private Slider _slider;
    private Health _stats;
    private float _deltaFill;

    private void OnEnable()
    {
        _wait = new WaitForSeconds(Time.fixedDeltaTime);
        _slider = GetComponent<Slider>();
        _stats = GetComponent<Health>();
        _stats.Changed += StartRoutine;
        _slider.maxValue = _stats.MaxHealth;
        _slider.minValue = _stats.MinHealth;
        _slider.value = _slider.maxValue;
        _healthPointsText.text = $"{_stats.MaxHealth}/{Mathf.Round(_slider.value)}";
        _deltaFill = _slider.maxValue / MaxPercent * _percentInSecond * Time.fixedDeltaTime;
    }

    private void OnValidate()
    {
        float minPercent = 0;
        _percentInSecond = Mathf.Clamp(_percentInSecond, minPercent, MaxPercent);
    }

    private void OnDisable()
    {
        _stats.Changed -= StartRoutine;
    }

    private void StartRoutine()
    {
        if (_routine != null)
        {
            StopCoroutine(_routine);
        }

        _routine = StartCoroutine(routine: ChangeValues());
    }

    private IEnumerator ChangeValues()
    {
        while (_slider.value != _stats.CurrentHelth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _stats.CurrentHelth, _deltaFill);
            _healthPointsText.text = $"{_stats.MaxHealth}/{Mathf.Round(_slider.value)}";
            yield return _wait;
        }
    }
}
