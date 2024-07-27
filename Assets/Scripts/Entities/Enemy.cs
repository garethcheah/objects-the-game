using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    protected Transform target;

    [SerializeField] protected float speed = 2.0f;

    private string _enemyName;
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

    public override void Move(Vector2 target)
    {
        Vector2 direction = target - new Vector2(transform.position.x, transform.position.y);

        direction.Normalize();
        //target.x = transform.position.x;
        //target.y = transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;

        transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
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
        GameManager.GetInstance().NotifyDeath(this);
        Destroy(gameObject);
        GameManager.GetInstance().scoreManager.IncrementScore();
    }

    public override void GetDamage(float damageValue)
    {
        Debug.Log("Enemy damaged.");

        health.RemoveHealth(damageValue);

        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }

    protected virtual void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position);
        }
        else
        {
            Move(speed);
        }
    }
}
