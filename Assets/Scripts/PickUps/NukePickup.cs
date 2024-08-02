using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickup : Pickup
{
    private Player _player;

    public override void OnPicked()
    {
        base.OnPicked();
        _player.AddNuke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPicked();
        }
    }

    private void Awake()
    {
        _player = GameManager.GetInstance().GetPlayer();
    }

    private void Start()
    {
        if (_player.nukeInventoryCount >= _player.nukeInventoryLimit)
        {
            Destroy(gameObject);
        }
    }
}
