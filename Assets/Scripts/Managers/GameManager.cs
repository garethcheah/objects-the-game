using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public PickupSpawner pickUpSpawner;

    public Action OnGameStart;
    public Action OnGameOver;

    [Header("Game Entities")]
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private GameObject _playerTemplate;

    [Header("Game Variables")]
    [SerializeField] private float _enemySpawnRate = 0.5f;

    private Player _player;
    private GameObject _tempEnemy;
    private bool _isEnemySpawning;
    //private bool _isPlaying;

    /// <summary>
    /// Singleton
    /// </summary>
    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    public void StartGame()
    {
        _player = Instantiate(_playerTemplate, Vector2.zero, Quaternion.identity).GetComponent<Player>();
        _player.OnDeath += StopGame;
        //_isPlaying = true;

        OnGameStart?.Invoke();
        StartCoroutine(GameStarter());
    }

    IEnumerator GameStarter()
    {
        yield return new WaitForSeconds(2.0f);
        _isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    public void StopGame()
    {
        _isEnemySpawning = false;
        scoreManager.SetHighScore();
        StartCoroutine(GameStopper());
    }

    IEnumerator GameStopper()
    {
        _isEnemySpawning = false;
        yield return new WaitForSeconds(2.0f);
        //_isPlaying = false;

        foreach (Enemy enemy in FindObjectsOfType(typeof(Enemy)))
        {
            Destroy(enemy.gameObject);
        }

        foreach (Pickup pickup in FindObjectsOfType(typeof(Pickup)))
        {
            Destroy(pickup.gameObject);
        }

        OnGameOver?.Invoke();
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
        _tempEnemy = Instantiate(_enemyTemplates[UnityEngine.Random.Range(0, _enemyTemplates.Length)]);
        _tempEnemy.transform.position = _spawnPositions[UnityEngine.Random.Range(0, _spawnPositions.Length)].position;
    }
}
