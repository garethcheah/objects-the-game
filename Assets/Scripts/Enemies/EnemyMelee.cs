using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    [SerializeField] private float _attackRange = 1.15f;
    [SerializeField] private float _attackRangeShieldBuffer = 1.0f;
    [SerializeField] private float _attackTime = 0.25f;

    private float _timer;
    private float _enemySpeed;
    private float _attackRangeBuffer;

    public EnemyMelee(string enemyName) : base(enemyName, EnemyType.Melee)
    {
        
    }

    public override void Attack(float interval)
    {
        if (_timer <= interval)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            _timer = 0.0f;
            target.GetComponent<IDamageable>().GetDamage(weapon.GetDamage());
            Debug.Log("_weapon.GetDamage()=" + weapon.GetDamage().ToString());
        }
    }

    protected override void Start()
    {
        base.Start();
        _enemySpeed = speed;

        // Set enemy health
        health = new Health(1, 0, 1);

        // Set enemy weapon
        weapon = new Weapon("Melee Weapon", 1.0f, 0.0f);
    }

    protected override void Update()
    {
        base.Update();

        if (target == null)
            return;

        if (GameManager.GetInstance().GetPlayer().IsShieldEnabled())
        {
            // Add buffer to attack range if player shield is enabled
            _attackRangeBuffer = _attackRangeShieldBuffer;
        }
        else
        {
            _attackRangeBuffer = 0.0f;
        }

        if (Vector2.Distance(transform.position, target.position) <= _attackRange + _attackRangeBuffer)
        {
            speed = 0.0f;
            Attack(_attackTime);
        }
        else
        {
            speed = _enemySpeed;
        }
    }
}
