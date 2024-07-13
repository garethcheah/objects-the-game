using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableObject : MonoBehaviour, IDamageable
{
    public Health health = new Health();
    public Weapon weapon = new Weapon();

    public abstract void Move(Vector2 direction, Vector2 target);

    public virtual void Move(Vector2 direction) { }

    public virtual void Move(float speed) { }

    public abstract void Shoot();

    public abstract void Attack(float interval);

    public abstract void Die();

    public virtual void GetDamage(float damageValue)
    {
        health.RemoveHealth(damageValue);

        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }
}
