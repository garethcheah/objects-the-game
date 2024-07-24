using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [Range(0.0f, 1.0f)] public float pickUpProbability;

    [SerializeField] private PickUpSpawn[] _pickUps;

    private List<PickUp> _pickUpPool = new List<PickUp>();
    private PickUp _chosenPickUp;

    public void SpawnPickup(Vector2 position)
    {
        if (_pickUpPool.Count <= 0)
            return;

        if (Random.Range(0.0f, 1.0f) < pickUpProbability)
        {
            _chosenPickUp = _pickUpPool[Random.Range(0, _pickUpPool.Count)];
            Instantiate(_chosenPickUp, position, Quaternion.identity);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (PickUpSpawn spawn in _pickUps)
        {
            for (int i = 0; i < spawn.spawnWeight; i++)
            {
                _pickUpPool.Add(spawn.pickUp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public struct PickUpSpawn
{
    public PickUp pickUp;
    public int spawnWeight;
}
