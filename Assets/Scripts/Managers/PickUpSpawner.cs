using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [Range(0.0f, 1.0f)] public float pickupProbability;

    [SerializeField] private PickupSpawn[] _pickups;

    private List<Pickup> _pickupPool = new List<Pickup>();
    private Pickup _chosenPickup;

    public void SpawnPickup(Vector2 position)
    {
        if (_pickupPool.Count <= 0)
            return;

        if (Random.Range(0.0f, 1.0f) < pickupProbability)
        {
            _chosenPickup = _pickupPool[Random.Range(0, _pickupPool.Count)];
            Instantiate(_chosenPickup, position, Quaternion.identity);
        }
    }

    private void Start()
    {
        foreach (PickupSpawn spawn in _pickups)
        {
            for (int i = 0; i < spawn.spawnWeight; i++)
            {
                _pickupPool.Add(spawn.pickup);
            }
        }
    }
}

[System.Serializable]
public struct PickupSpawn
{
    public Pickup pickup;
    public int spawnWeight;
}
