using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup, IDamageable
{
    [SerializeField] private float _healthMin;
    [SerializeField] private float _healthMax;
    [SerializeField] private AudioClip _audioClipPicked;

    public override void OnPicked()
    {
        base.OnPicked();

        // Increase health
        float health = Random.Range(_healthMin, _healthMax);

        var player = GameManager.instance.GetPlayer();

        player.health.AddHealth(health);
        SoundFXManager.instance.PlaySoundFXClip(_audioClipPicked, player.transform, 1.0f);
    }

    public void GetDamage(float damage)
    {
        // This allows _player to shoot the pickups to collect them
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
