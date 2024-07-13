using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackTime;

    private float _timer;

    public EnemyMelee(string enemyName) : base(enemyName, EnemyType.Melee)
    {
        
    }

    public override void GetDamage(float damageValue)
    {
        health.RemoveHealth(damageValue);
    }

    public override void Attack(float interval)
    {
        if (_timer <= interval)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            _timer = 0;
            target.GetComponent<IDamageable>().GetDamage(1);
        }
    }

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
    }

    protected override void Update()
    {
        base.Update();

        if (target == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, target.position) < _attackRange)
        {
            Attack(_attackTime);
        }
    }
}
