using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    public Transform target;

    private string _enemyName;
    private float _speed;
    private EnemyType _enemyType;

    public Enemy(string enemyName, EnemyType enemyType)
    {
        _enemyName = enemyName;
        _enemyType = enemyType;
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        Debug.Log($"Enemy {_enemyName} move towards {this.target.name}.");
    }

    public override void Move(Vector2 direction)
    {
        direction.x = transform.position.x;
        direction.y = transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
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

    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position);
        }
        else
        {
            Move(_speed);
        }
    }
}
