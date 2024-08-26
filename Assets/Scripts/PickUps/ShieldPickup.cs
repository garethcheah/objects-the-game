using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : Pickup
{
    [SerializeField] private float _shieldDuration = 30.0f;

    public override void OnPicked()
    {
        base.OnPicked();

        var player = GameManager.instance.GetPlayer();

        player.EnableShield(_shieldDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPicked();
        }
    }
}
