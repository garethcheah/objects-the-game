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

    public override void Move()
    {
        Debug.Log($"Enemy {_enemyName} move towards {_target.name}.");
    }

    public override void Shoot(Vector3 direction, float speed)
    {
        Debug.Log($"Enemy {_enemyName} shoots bullet at {direction} with a speed of {speed}.");
    }

    public override void Attack(float interval)
    {
        Debug.Log($"Enemy {_enemyName} attacking with an interval of {interval}.");
    }

    public override void Die()
    {
        Debug.Log($"Enemy {_enemyName} dead.");
    }
}
