using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : Pickup, IDamageable
{
    public override void OnPicked()
    {
        base.OnPicked();

        var player = GameManager.GetInstance().GetPlayer();

        player.EnableShield();
    }

    public void GetDamage(float damage)
    {
        // This allows player to shoot  the pickups to collect them
        OnPicked();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPicked();
        }
    }
}
