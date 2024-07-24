using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp, IDamageable
{
    [SerializeField] private float _healthMin;
    [SerializeField] private float _healthMax;

    public override void OnPicked()
    {
        base.OnPicked();

        // Increase health
        float health = Random.Range(_healthMin, _healthMax);

        var player = GameManager.GetInstance().GetPlayer();

        player.health.AddHealth(health);

        Debug.Log("Health added.");
    }

    public void GetDamage(float damage)
    {
        // This allows player to shoot  the pickups to collect them
        OnPicked();
    }
}
