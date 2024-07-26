using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMachineGun : Enemy
{
    [SerializeField] private float _shootingRange = 10.0f;
    [SerializeField] private float _shootingRate = 0.2f;
    [SerializeField] private float _weaponDamage = 1.0f;
    [SerializeField] private float _bulletSpeed = 15.0f;
    [SerializeField] private Bullet _bullet;

    private float _timer;
    private float _enemySpeed;

    public EnemyMachineGun(string enemyName) : base(enemyName, EnemyType.MachineGun)
    {

    }

    public override void Shoot()
    {
        if (_timer >= _shootingRate)
        {
            _timer = 0.0f;
            weapon.Shoot(_bullet, this, "Player");
        }
    }

    protected override void Start()
    {
        base.Start();
        _timer = _shootingRate;
        _enemySpeed = speed;

        // Set enemy health
        health = new Health(1, 0, 1);

        // Set enemy weapon
        weapon = new Weapon("Machine Gun", _weaponDamage, _bulletSpeed);
    }

    protected override void Update()
    {
        base.Update();
        _timer += Time.deltaTime;

        if (target == null)
            return;

        if (Vector2.Distance(transform.position, target.position) <= _shootingRange)
        {
            speed = 0.0f;
            Shoot();
        }
        else
        {
            speed = _enemySpeed;
        }
    }
}
