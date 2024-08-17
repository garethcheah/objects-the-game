using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : PlayableObject
{
    public Action OnDeath;
    public Action<int> OnNukeInventoryUpdate;

    public int nukeInventoryCount = 0;
    public int nukeInventoryLimit = 3;

    [SerializeField] private float _speed = 100.0f;
    [SerializeField] private float _weaponDamage = 1.0f;
    [SerializeField] private float _bulletSpeed = 15.0f;
    [SerializeField] private float _shootingRate = 0.2f;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _shield;
    [SerializeField] private GameObject _shieldDurationMeter;

    private float _timer;
    private float _timerShield;
    private float _shieldDuration;
    private Camera _mainCamera;
    private Rigidbody2D _rbPlayer;

    /// <summary>
    /// Moves _player object in a specified direction and rotates _player towards a specified target
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="target"></param>
    public override void Move(Vector2 direction, Vector2 target)
    {
        _rbPlayer.velocity = direction * _speed * Time.deltaTime;

        Vector3 playerScreenPosition = _mainCamera.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPosition.x;
        target.y -= playerScreenPosition.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90.0f; // Add 90 degree offset to align exit point for bullets to the right position of _player sprite
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
        else if (_shield.activeSelf && damageValue > 20.0f)
        {
            DisableShield();
        }
    }

    public void EnableShield(float duration)
    {
        _shield.SetActive(true);
        _shieldDurationMeter.SetActive(true);
        _shieldDuration = duration;
        _timerShield = duration;
    }

    public bool IsShieldEnabled()
    {
        return _shield.activeSelf;
    }

    public void AddNuke()
    {
        if (nukeInventoryCount < nukeInventoryLimit)
        {
            nukeInventoryCount++;
            OnNukeInventoryUpdate?.Invoke(nukeInventoryCount);
        }
    }

    public void UseNuke()
    {
        if (nukeInventoryCount > 0)
        {
            GameManager.GetInstance().DestroyAllEnemiesAndPickups(true);
            nukeInventoryCount--;
            OnNukeInventoryUpdate?.Invoke(nukeInventoryCount);
        }
    }

    private void Awake()
    {
        _mainCamera = Camera.main;
        _rbPlayer = GetComponent<Rigidbody2D>();
        _timer = _shootingRate;
        DisableShield();

        // Set _player health
        health = new Health(100.0f, 0.5f, 100.0f);

        // Set _player _weapon
        weapon = new Weapon("Player Weapon", _weaponDamage, _bulletSpeed);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        health.RegenHealth();

        if (_shield.activeSelf)
        {
            if (_timerShield > 0)
            {
                _timerShield -= Time.deltaTime;
                UpdateShieldDurationMeter(_timerShield, _shieldDuration);
            }
            else
            {
                DisableShield();
            }
        }
    }

    private void UpdateShieldDurationMeter(float timeRemaining, float duration)
    {
        float percentTimeRemaining = timeRemaining / duration;
        int numberOfDurationUnitsToDisplay = Mathf.RoundToInt(percentTimeRemaining * 4.0f);

        for (int i = 0; i < _shieldDurationMeter.transform.childCount; i++)
        {
            _shieldDurationMeter.transform.GetChild(i).gameObject.SetActive(numberOfDurationUnitsToDisplay > 0);

            numberOfDurationUnitsToDisplay--;
        }
    }

    private void DisableShield()
    {
        _shield.SetActive(false);
        _shieldDurationMeter.SetActive(false);
    }
}
