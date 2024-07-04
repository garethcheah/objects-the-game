using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    private float _damage;

    private void Move(Transform target)
    {
        Debug.Log($"Bullet moving towards {target.name} to do damage of {_damage}.");
    }

    private void Damage()
    {
        Debug.Log("Something damaged!");
    }
}
