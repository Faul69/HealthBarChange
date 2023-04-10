using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Stats))]

public class FillSlider : MonoBehaviour
{
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
    }

    private void FixedUpdate()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _stats.CurrentHelth, _deltaFill);
    }

    private void OnValidate()
    {
        float minPercent = 0;

        if (_percentInSecond > MaxPercent)
        {
            _percentInSecond = MaxPercent;
        }
        else if (_percentInSecond < minPercent)
        {
            _percentInSecond = minPercent;
        }
    }
}
