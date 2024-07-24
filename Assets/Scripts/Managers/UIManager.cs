using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtHealth;
    [SerializeField] private TMP_Text _txtScore;
    [SerializeField] private TMP_Text _txtHighScore;
    
    private Player _player;
    private ScoreManager _scoreManager;

    public void UpdateHealth(float currentHealth)
    {
        _txtHealth.SetText(currentHealth.ToString());
    }

    public void UpdateScore()
    {
        _txtScore.SetText(_scoreManager.GetScore().ToString());
    }

    public void UpdateHighScore()
    {
        _txtHighScore.SetText(_scoreManager.GetHighScore().ToString());
    }

    // Start is called before the first frame update
    private void Start()
    {
        _scoreManager = GameManager.GetInstance().scoreManager;
        _player = GameManager.GetInstance().GetPlayer();

        //Subscribe to Action
        _player.health.OnHealUpdate += UpdateHealth;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnDisable()
    {
        _player.health.OnHealUpdate -= UpdateHealth;
    }
}
