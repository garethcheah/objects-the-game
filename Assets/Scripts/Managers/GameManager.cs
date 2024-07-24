using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public PickUpSpawner pickUpSpawner;

    [Header("Game Entities")]
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private Transform[] _spawnPositions;

    [Header("Game Variables")]
    [SerializeField] private float _enemySpawnRate;

    private Player _player;
    private GameObject _tempEnemy;
    private bool _isEnemySpawning;

    /// <summary>
    /// Singleton
    /// </summary>
    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    public void NotifyDeath(Enemy enemy)
    {
        pickUpSpawner.SpawnPickup(enemy.transform.position);
    }

    public void FindPlayer()
    {
        try
        {
            _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
        catch (NullReferenceException e)
        {
            Debug.Log("No player in the scene. Exception: " + e.Message);
        }
    }

    public Player GetPlayer()
    {
        return _player;
    }

    private void Awake()
    {
        SetInstance();
    }

    private void Start()
    {
        FindPlayer();
        _isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    private void SetInstance()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }

    private IEnumerator EnemySpawner()
    {
        while (_isEnemySpawning)
        {
            //Anything above here will fire when the StartCoroutine is called.
            yield return new WaitForSeconds(1.0f / _enemySpawnRate);
            //Anything below here will be called after the wait.
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        _tempEnemy = Instantiate(_enemyTemplate);
        _tempEnemy.transform.position = _spawnPositions[UnityEngine.Random.Range(0, _spawnPositions.Length)].position;
    }
}
