using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event UnityAction Changed;

    public float CurrentHelth { get; private set; }
    public float MinHealth { get; private set; }
    public float MaxHealth => _maxHealth;

    private void OnEnable()
    {
        MinHealth = 0f;
        CurrentHelth = _maxHealth;
    }

    public void Damage(float damage)
    {
        CurrentHelth = Mathf.MoveTowards(CurrentHelth, MinHealth, damage);
        Changed?.Invoke();
    }

    public void Heal(float heal)
    {
        CurrentHelth = Mathf.MoveTowards(CurrentHelth, _maxHealth, heal);
        Changed?.Invoke();
    }
}
