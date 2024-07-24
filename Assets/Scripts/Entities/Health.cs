using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public Action<float> OnHealUpdate;

    private float _currentHealth;
    private float _maxHealth;
    private float _healthRegenRate;

    public Health() { }

    public Health(float maxHealth, float healthRegenRate, float currentHealth = 100)
    {
        _currentHealth = currentHealth;
        _maxHealth = maxHealth;
        _healthRegenRate = healthRegenRate;
    }

    public float GetHealth()
    {
        return _currentHealth;
    }

    public void SetHealth(float value)
    {
        if (value > _maxHealth || value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _currentHealth = value;
    }   

    public void AddHealth(float value)
    {
        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + value);
        OnHealUpdate?.Invoke(_currentHealth);
    }

    public void RemoveHealth(float value)
    {
        _currentHealth = Mathf.Max(0, _currentHealth - value);
        OnHealUpdate?.Invoke(_currentHealth);
    }

    public void RegenHealth()
    {
        AddHealth(_healthRegenRate * Time.deltaTime);
    }
}
