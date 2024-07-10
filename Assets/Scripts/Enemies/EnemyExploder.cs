using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExploder : Enemy
{
    private float explosiveForce;

    public EnemyExploder(string enemyName, float explosiveForce) : base(enemyName, EnemyType.Exploder)
    {
        this.explosiveForce = explosiveForce;
    }

    public override void Shoot()
    {
        Debug.Log("The Exploder enemy type has no implementation of Shoot(). Use Explode() instead.");
    }

    public void Explode()
    {
        
    }
}
