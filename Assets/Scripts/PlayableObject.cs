using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableObject : MonoBehaviour
{
    public Health health = new Health();
    public Weapon weapon = new Weapon();

    public virtual void Move()
    {
        Debug.Log("BASE: Moving.");
    }

    public virtual void Shoot(Vector3 direction, float speed)
    {
        Debug.Log($"BASE: Shooting towardss {direction} with a speed of {speed}.");
    }

    public virtual void Attack(float interval)
    {
        Debug.Log($"BASE: Attacking with {interval} interval.");
    }

    public virtual void Die()
    {
        Debug.Log("BASE: Dying");
    }
}
