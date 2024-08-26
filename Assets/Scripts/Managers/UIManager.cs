using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _gameStatsPanel;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _controlsPanel;
    [SerializeField] private GameObject _enemyInfoPanel;
    [SerializeField] private GameObject _powerupInfoPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _textGameOver;
    [SerializeField] private TMP_Text _textMenuHighScore;

    [Header("Gameplay")]
    [SerializeField] private TMP_Text _textHealth;
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private TMP_Text _textHighScore;
    [SerializeField] private GameObject _nukeInventory;

    private Player _player;
    private ScoreManager _scoreManager;

    public void UpdateHealth(float currentHealth)
    {
        _textHealth.SetText($"Health: {currentHealth.ToString("0.00")}");
    }

    public void UpdateScore()
    {
        _textScore.SetText(_scoreManager.GetScore().ToString());
    }

    public void UpdateHighScore()
    {
        int highScore = _scoreManager.GetHighScore();
        _textHighScore.SetText(highScore.ToString());
        _textMenuHighScore.SetText($"High Score: {highScore.ToString()}");
    }

    public void GameStarted()
    {
        _player = GameManager.instance.GetPlayer();
        _player.health.OnHealthUpdate += UpdateHealth;
        _player.OnNukeInventoryUpdate += UpdateNukeInventory;
        UpdateNukeInventory(0);
        _menuPanel.SetActive(false);
        _gameStatsPanel.SetActive(true);
    }

    public void GameOver()
    {
        _gameStatsPanel.SetActive(false);
        _menuPanel.SetActive(true);
        _textGameOver.SetActive(true);
    }

    public void DisplayMainMenu()
    {
        _controlsPanel.SetActive(false);
        _enemyInfoPanel.SetActive(false);
        _powerupInfoPanel.SetActive(false);
        _menuPanel.SetActive(true);
        GameManager.instance.PlayMenuSelectFX();
    }

    public void DisplayControlsPanel()
    {
        _menuPanel.SetActive(false);
        _enemyInfoPanel.SetActive(false);
        _powerupInfoPanel.SetActive(false);
        _controlsPanel.SetActive(true);
        GameManager.instance.PlayMenuSelectFX();
    }

    public void DisplayEnemyInfoPanel()
    {
        _menuPanel.SetActive(false);
        _controlsPanel.SetActive(false);
        _powerupInfoPanel.SetActive(false);
        _enemyInfoPanel.SetActive(true);
        GameManager.instance.PlayMenuSelectFX();
    }

    public void DisplayPowerupInfoPanel()
    {
        _menuPanel.SetActive(false);
        _controlsPanel.SetActive(false);
        _enemyInfoPanel.SetActive(false);
        _powerupInfoPanel.SetActive(true);
        GameManager.instance.PlayMenuSelectFX();
    }

    public void DisplayPausePanel()
    {
        _gameStatsPanel.SetActive(false);
        _pausePanel.SetActive(true);
    }

    public void HidePausePanel()
    {
        _pausePanel.SetActive(false);
        _gameStatsPanel.SetActive(true);
    }

    private void Awake()
    {
        _controlsPanel.SetActive(false);
        _enemyInfoPanel.SetActive(false);
        _powerupInfoPanel.SetActive(false);
        _pausePanel.SetActive(false);
        _menuPanel.SetActive(true);
        _gameStatsPanel.SetActive(false);
        _textGameOver.SetActive(false);
        _scoreManager = GameManager.instance.scoreManager;

        GameManager.instance.OnGameStart += GameStarted;
        GameManager.instance.OnGameOver += GameOver;
        GameManager.instance.OnGamePause += DisplayPausePanel;
        GameManager.instance.OnGameUnpause += HidePausePanel;
    }

    private void UpdateNukeInventory(int nukeInventoryCount)
    {
        int activeNukeCount = 0;

        for (int i = 0; i < _nukeInventory.transform.childCount; i++)
        {
            _nukeInventory.transform.GetChild(i).gameObject.SetActive(activeNukeCount < nukeInventoryCount);
            activeNukeCount++;
        }
    }
}
