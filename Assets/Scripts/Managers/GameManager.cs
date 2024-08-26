using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static GameManager instance;

    public ScoreManager scoreManager;
    public PickupSpawner pickUpSpawner;
    public bool isStarted;
    public bool isPaused;

    public Action OnGameStart;
    public Action OnGameOver;
    public Action OnGamePause;
    public Action OnGameUnpause;

    [Header("Game Entities")]
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private GameObject _playerTemplate;

    [Header("Game Variables")]
    [SerializeField] private float _enemySpawnRate = 0.4f;
    [SerializeField] private float _maxEnemySpawnRate = 3.0f;
    [SerializeField] private float _difficultyStepInterval = 20.0f;
    [SerializeField] private float _difficultyStepRate = 0.2f;

    [Header("Sound FX")]
    [SerializeField] private AudioClip _audioClipMenuSelect;

    private Player _player;
    private GameObject _tempEnemy;
    private bool _isEnemySpawning;
    private float _difficultyStepTimer;

    public void StartGame()
    {
        _player = Instantiate(_playerTemplate, Vector2.zero, Quaternion.identity).GetComponent<Player>();
        _player.OnDeath += StopGame;
        isStarted = true;
        PlayMenuSelectFX();

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
        isStarted = false;
        scoreManager.SetHighScore();
        StartCoroutine(GameStopper());
    }

    IEnumerator GameStopper()
    {
        _isEnemySpawning = false;
        yield return new WaitForSeconds(2.0f);

        DestroyAllEnemiesAndPickups(false);

        OnGameOver?.Invoke();
    }

    public void DestroyAllEnemiesAndPickups(bool updateScore)
    {
        foreach (Enemy enemy in FindObjectsOfType(typeof(Enemy)))
        {
            Destroy(enemy.gameObject);

            if (updateScore)
            {
                scoreManager.IncrementScore();
            }
        }

        foreach (Pickup pickup in FindObjectsOfType(typeof(Pickup)))
        {
            Destroy(pickup.gameObject);
        }
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
            Debug.Log("No _player in the scene. Exception: " + e.Message);
        }
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public void PlayMenuSelectFX()
    {
        SoundFXManager.instance.PlaySoundFXClip(_audioClipMenuSelect, transform, 1.0f);
    }

    public void PauseGame()
    {
        isPaused = true;
        _isEnemySpawning = false;
        Time.timeScale = 0.0f;
        OnGamePause?.Invoke();
    }

    public void UnpauseGame()
    {
        isPaused = false;
        _isEnemySpawning = true;
        Time.timeScale = 1.0f;
        OnGameUnpause?.Invoke();
    }

    private void Awake()
    {
        SetInstance();
    }

    private void Start()
    {
        FindPlayer();
    }

    private void Update()
    {
        // Increase game difficulty over time by changing enemy spawn rate
        if (_enemySpawnRate < _maxEnemySpawnRate)
        {
            _difficultyStepTimer += Time.deltaTime;

            if (_difficultyStepTimer >= _difficultyStepInterval)
            {
                _enemySpawnRate += _difficultyStepRate;
                _difficultyStepTimer = 0;
            }
        }
    }

    private void SetInstance()
    {
        //if (instance != null && instance != this)
        //{
        //    Destroy(instance);
        //}
        //else
        //{
        //    instance = this;
        //}

        if (instance == null)
        {
            instance = this;
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
