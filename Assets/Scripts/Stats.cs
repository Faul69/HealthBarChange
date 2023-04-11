using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damagePoints;
    [SerializeField] private float _healPoints;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healbutton;

    private UnityAction _damage;
    private UnityAction _heal;
    public float CurrentHelth { get; private set; }
    public float MinHealth { get; private set; }
    public float MaxHealth => _maxHealth;

    private void OnEnable()
    {
        MinHealth = 0f;
        CurrentHelth = _maxHealth;
        _damage += Damage;
        _heal += Heal;
        _damageButton.onClick.AddListener(_damage);
        _healbutton.onClick.AddListener(_heal);
    }

    public void Damage()
    {
        CurrentHelth = Mathf.MoveTowards(CurrentHelth, MinHealth, _damagePoints);
    }

    public void Heal()
    {
        CurrentHelth = Mathf.MoveTowards(CurrentHelth, _maxHealth, _healPoints);
    }
}
