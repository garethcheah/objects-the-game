using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float _currentHealth;
    private float _maxHealth;
    private float _healthRegenRate;

    public Health()
    {

    }

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

    public void AddHealth(float value)
    {
        _currentHealth += value;
    }

    public void RemoveHealth(float value)
    {
        _currentHealth -= value;
    }
}
