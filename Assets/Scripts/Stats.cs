using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private UnityEvent _clicked;

    public float CurrentHelth { get; private set; }
    public float MinHealth { get; private set; }
    public float MaxHealth => _maxHealth;

    private void OnEnable()
    {
        MinHealth = 0f;
        CurrentHelth = _maxHealth;
    }

    public void Damage(float damagePoints)
    {
        CurrentHelth = Mathf.MoveTowards(CurrentHelth, MinHealth, damagePoints);
        _clicked.Invoke();
    }

    public void Heal(float healPoints)
    {
        CurrentHelth = Mathf.MoveTowards(CurrentHelth, _maxHealth, healPoints);
        _clicked.Invoke();
    }
}
