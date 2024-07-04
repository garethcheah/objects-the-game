using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Health health = new Health();
    public Weapon weapon = new Weapon();

    private string _nickName;
    private float _speed;

    public void Move(Vector3 direction)
    {
        Debug.Log($"Move towards {direction}.");
    }

    public void Shoot(Vector3 direction, float speed)
    {
        Debug.Log($"Shoots bullet at {direction} with a speed of {speed}.");
    }

    public void Die()
    {
        Debug.Log("Player dead.");
    }
}
