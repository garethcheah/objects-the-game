using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickup : Pickup
{
    [SerializeField] AudioClip _audioClipPicked;

    private Player _player;

    public override void OnPicked()
    {
        base.OnPicked();
        _player.AddNuke();
        SoundFXManager.instance.PlaySoundFXClip(_audioClipPicked, _player.transform, 1.0f);
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
        _player = GameManager.instance.GetPlayer();
    }

    private void Start()
    {
        if (_player.nukeInventoryCount >= _player.nukeInventoryLimit)
        {
            Destroy(gameObject);
        }
    }
}
