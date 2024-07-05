using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    private int _attackInterval;

    public EnemyMelee(string enemyName, int attackInterval) : base(enemyName, EnemyType.Melee)
    {
        _attackInterval = attackInterval;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        base.Attack(_attackInterval);
    }
}
