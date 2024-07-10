using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    private string _enemyName;
    private float _speed;
    private EnemyType _enemyType;
    private Transform _target;

    public Enemy(string enemyName, EnemyType enemyType)
    {
        _enemyName = enemyName;
        _enemyType = enemyType;
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        Debug.Log($"Enemy {_enemyName} move towards {_target.name}.");
    }

    public override void Shoot()
    {
        Debug.Log("Enemy shooting.");
    }

    public override void Attack(float interval)
    {
        Debug.Log($"Enemy {_enemyName} attacking with an interval of {interval}.");
    }

    public override void Die()
    {
        Debug.Log($"Enemy {_enemyName} dead.");
    }

    public override void GetDamage(float damageValue)
    {
        throw new System.NotImplementedException();
    }
}
