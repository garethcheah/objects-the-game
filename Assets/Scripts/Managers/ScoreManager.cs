using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    private int _highScore;

    public UnityEvent OnScoreUpdated;
    public UnityEvent OnHighScoreUpdated;

    public int GetScore()
    {
        return _score;
    }
    
    public int GetHighScore()
    {
        return _highScore;
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", _highScore);
    }

    public void IncrementScore()
    {
        _score++;
        OnScoreUpdated?.Invoke();

        if (_score > _highScore)
        {
            _highScore = _score;
            OnHighScoreUpdated?.Invoke();
        }
    }

    public void OnGameStart()
    {
        _score = 0;
    }

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        OnHighScoreUpdated?.Invoke();
        GameManager.GetInstance().OnGameStart += OnGameStart;
    }
}
