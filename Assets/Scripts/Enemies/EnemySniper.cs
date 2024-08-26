using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper : Enemy
{
    [SerializeField] private float _shootingRange = 8.0f;
    [SerializeField] private float _shootingRate = 3.0f;
    [SerializeField] private float _weaponDamage = 5.0f;
    [SerializeField] private float _bulletSpeed = 10.0f;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private AudioClip _audioClipWeapon;

    private float _timer;
    private float _enemySpeed;
    private LineRenderer _laserAim;

    public EnemySniper(string enemyName) : base(enemyName, EnemyType.Sniper)
    {

    }

    public override void Shoot()
    {
        if (_laserAim.isVisible && _timer >= _shootingRate)
        {
            _timer = 0.0f;
            weapon.Shoot(_bullet, this, "Player");
            SoundFXManager.instance.PlaySoundFXClip(_audioClipWeapon, transform, 1.0f);
        }
    }

    protected override void Start()
    {
        base.Start();
        _enemySpeed = speed;
        _laserAim = GetComponent<LineRenderer>();
        _laserAim.enabled = false;

        // Set enemy health
        health = new Health(1, 0, 1);

        // Set enemy weapon
        weapon = new Weapon("Sniper Rifle", _weaponDamage, _bulletSpeed);
    }

    protected override void Update()
    {
        base.Update();
        _timer += Time.deltaTime;

        if (target == null)
        {
            DisableLaserAim();
            return;
        }

        if (Vector2.Distance(transform.position, target.position) <= _shootingRange)
        {
            speed = 0.0f;
            EnableLaserAim();
            Shoot();
        }
        else
        {
            DisableLaserAim();
            speed = _enemySpeed;
        }
    }

    private void EnableLaserAim()
    {
        if (target != null)
        {
            _laserAim.enabled = true;
            _laserAim.SetPosition(0, transform.position);
            _laserAim.SetPosition(1, target.position);
        }
    }

    private void DisableLaserAim()
    {
        _laserAim.enabled = false;
    }
}
