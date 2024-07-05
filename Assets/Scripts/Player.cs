using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    private string _playerName;
    private float _speed;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        health = new Health(100.0f, 0.5f, 100.0f);
    }

    public override void Move()
    {
        base.Move();
    }

    public override void Shoot(Vector3 direction, float speed)
    {
        Debug.Log($"Shoots bullet at {direction} with a speed of {speed}.");
    }

    public override void Die()
    {
        Debug.Log("Player dead.");
    }
}
