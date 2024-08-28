using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExploder : Enemy
{
    [SerializeField] private float _explodeRange = 1.5f;
    [SerializeField] private float _explodeRangeShieldBuffer = 1.0f;
    [SerializeField] private float _explodeDamage = 50.0f;
    [SerializeField] private AudioClip _audioClipExplode;

    private SpriteRenderer _srEnemy;
    private ParticleSystem _explosionParticleSystem;
    private bool _hasAlreadyExploded = false;
    private float _explodeRangeBuffer;
    private IDamageable _damageable;

    public EnemyExploder(string enemyName) : base(enemyName, EnemyType.Exploder)
    {
        
    }

    public void Explode()
    {
        if (!_hasAlreadyExploded)
        {
            // The line below was causing memory access out of bounds error on WebGL.
            // Current solution: Set _damageable using GameManager.instance.GetPlayer() in the Start() method.
            //target.GetComponent<IDamageable>().GetDamage(_explodeDamage);
            _damageable.GetDamage(_explodeDamage);
            _explosionParticleSystem.Play();
            _hasAlreadyExploded = true;
            Destroy(_srEnemy);
            Invoke("Die", _explosionParticleSystem.main.duration);
            SoundFXManager.instance.PlaySoundFXClip(_audioClipExplode, transform, 1.0f);
        }
    }

    protected override void Start()
    {
        base.Start();

        _srEnemy = GetComponent<SpriteRenderer>();
        _explosionParticleSystem = GetComponentInChildren<ParticleSystem>();
        _damageable = GameManager.instance.GetPlayer();

        // Set enemy health
        health = new Health(1, 0, 1);
    }

    protected override void Update()
    {
        base.Update();

        if (target == null)
            return;

        if (GameManager.instance.GetPlayer().IsShieldEnabled())
        {
            // Add buffer to attack range if player shield is enabled
            _explodeRangeBuffer = _explodeRangeShieldBuffer;
        }
        else
        {
            _explodeRangeBuffer = 0.0f;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        if (Vector2.Distance(transform.position, target.position) <= _explodeRange + _explodeRangeBuffer)
        {
            Explode();
        }
    }
}
