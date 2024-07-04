using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public Health health = new Health();
    public Weapon weapon = new Weapon();

    private string _name;
    private float _speed;
    private EnemyType _enemyType;

    public Enemy(string name, EnemyType enemyType)
    {
        _name = name;
        _enemyType = enemyType;
    }

    public void Move(Transform target)
    {
        Debug.Log($"Enemy {_name} move towards {target.name}.");
    }

    public void Shoot(Vector3 direction, float speed)
    {
        Debug.Log($"Enemy {_name} shoots bullet at {direction} with a speed of {speed}.");
    }

    public void Attack(float interval)
    {
        Debug.Log($"Enemy {_name} attacking with an interval of {interval}.");
    }

    public void Die()
    {
        Debug.Log("Enemy {_name} dead.");
    }
}
