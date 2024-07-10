using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    private string _name;
    private float _damage;

    public Weapon()
    {

    }

    public Weapon(string name, float damage)
    {
        _name = name;
        _damage = damage;
    }

    public void Shoot()
    {
        Debug.Log($"Shooting from gun.");
    }
}
