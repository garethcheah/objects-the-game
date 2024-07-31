using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : PlayableObject
{
    public Action OnDeath;

    [SerializeField] private float _speed = 100.0f;
    [SerializeField] private float _weaponDamage = 1.0f;
    [SerializeField] private float _bulletSpeed = 15.0f;
    [SerializeField] private float _shootingRate = 0.2f;
    [SerializeField] private Bullet _bullet;

    private float _timer;
    private Camera _mainCamera;
    private Rigidbody2D _rbPlayer;
    private GameObject _shield;

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
        if (_timer >= _shootingRate)
        {
            Debug.Log("Player shooting.");
            _timer = 0.0f;
            weapon.Shoot(_bullet, this, "Enemy");
        }
    }

    public override void Attack(float interval)
    {
        
    }

    public override void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public override void GetDamage(float damageValue)
    {
        health.RemoveHealth(damageValue);

        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }

    public void EnableShield(float duration)
    {
        _shield.SetActive(true);
        Invoke("DisableShield", duration);
    }

    private void Awake()
    {
        _mainCamera = Camera.main;
        _rbPlayer = GetComponent<Rigidbody2D>();
        _timer = _shootingRate;
        _shield = GameObject.Find("Shield");
        _shield.SetActive(false);

        // Set player health
        health = new Health(100.0f, 0.5f, 100.0f);

        // Set player _weapon
        weapon = new Weapon("Player Weapon", _weaponDamage, _bulletSpeed);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        health.RegenHealth();
    }

    private void DisableShield()
    {
        _shield.SetActive(false);
    }
}
