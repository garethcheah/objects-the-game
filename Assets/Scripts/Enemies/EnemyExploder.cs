using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExploder : Enemy
{
    [SerializeField] private float _explodeRange = 1.5f;
    [SerializeField] private float _explodeDamage = 50.0f;

    private SpriteRenderer _srEnemy;
    private ParticleSystem _explosionParticleSystem;
    private bool _hasAlreadyExploded = false;

    public EnemyExploder(string enemyName) : base(enemyName, EnemyType.Exploder)
    {
        
    }

    public void Explode()
    {
        if (!_hasAlreadyExploded)
        {
            target.GetComponent<IDamageable>().GetDamage(_explodeDamage);
            _explosionParticleSystem.Play();
            _hasAlreadyExploded = true;
            Destroy(_srEnemy);
            Invoke("Die", _explosionParticleSystem.main.duration);
        }
    }

    protected override void Start()
    {
        base.Start();

        _srEnemy = GetComponent<SpriteRenderer>();
        _explosionParticleSystem = GetComponentInChildren<ParticleSystem>();

        // Set enemy health
        health = new Health(1, 0, 1);
    }

    protected override void Update()
    {
        base.Update();

        if (target == null)
            return;

        if (Vector2.Distance(transform.position, target.position) <= _explodeRange)
        {
            Explode();
        }
    }
}
