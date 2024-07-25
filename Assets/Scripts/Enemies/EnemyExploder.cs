using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExploder : Enemy
{
    [SerializeField] private float explodeRange = 10.0f;
    [SerializeField] private float _explodeDamage = 50.0f;

    public EnemyExploder(string enemyName) : base(enemyName, EnemyType.Exploder)
    {
        
    }

    public void Explode()
    {
        target.GetComponent<IDamageable>().GetDamage(_explodeDamage);
        Die();
    }

    protected override void Start()
    {
        base.Start();

        // Set enemy health
        health = new Health(1, 0, 1);
    }

    protected override void Update()
    {
        base.Update();

        if (target == null)
            return;

        if (Vector2.Distance(transform.position, target.position) <= explodeRange)
        {
            Explode();
        }
    }
}
