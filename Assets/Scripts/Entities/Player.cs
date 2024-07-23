using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    public Action<float> OnHealthUpdate;

    [SerializeField] private float _speed;
    [SerializeField] private float _weaponDamage = 1.0f;
    [SerializeField] private float _bulletSpeed = 15.0f;
    [SerializeField] private Bullet _bullet;

    private string _playerName;
    private Vector3 _direction;
    private Camera _mainCamera;
    private Rigidbody2D _rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _rbPlayer = GetComponent<Rigidbody2D>();

        // Set player health
        health = new Health(100.0f, 0.5f, 100.0f);

        // Set player _weapon
        weapon = new Weapon("Player Weapon", _weaponDamage, _bulletSpeed);
    }

    /// <summary>
    /// Moves player object in a specified direction and rotates player towards a specified target
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="target"></param>
    public override void Move(Vector2 direction, Vector2 target)
    {
        _rbPlayer.velocity = direction * _speed * Time.deltaTime;

        Vector3 playerScreenPosition = _mainCamera.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPosition.x;
        target.y -= playerScreenPosition.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90.0f; // Add 90 degree offset to align exit point for bullets to the right position of player sprite
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Shoot()
    {
        Debug.Log("Player shooting.");
        weapon.Shoot(_bullet, this, "Enemy");
    }

    public override void Attack(float interval)
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        Debug.Log("Player dead.");
        Destroy(gameObject);
    }

    // This method is already defined in PlayableObject - Removing for now
    //public override void GetDamage(float damageValue)
    //{
    //    _health.RemoveHealth(damageValue);

    //    if (_health.GetHealth() <= 0)
    //    {
    //        Die();
    //    }
    //}
}
