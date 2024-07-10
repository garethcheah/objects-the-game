using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    [SerializeField] private float _speed;

    private string _playerName;
    private Vector3 _direction;
    private Camera _mainCamera;
    private Rigidbody2D _rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _rbPlayer = GetComponent<Rigidbody2D>();
        health = new Health(100.0f, 0.5f, 100.0f);
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        _rbPlayer.velocity = direction * _speed * Time.deltaTime;

        Vector3 playerScreenPosition = _mainCamera.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPosition.x;
        target.y -= playerScreenPosition.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Shoot()
    {
        Debug.Log("Player shooting.");
    }

    public override void Attack(float interval)
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        Debug.Log("Player dead.");
    }

    public override void GetDamage(float damageValue)
    {
        throw new System.NotImplementedException();
    }
}
