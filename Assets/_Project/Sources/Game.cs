using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void Start()
    {
        Time.timeScale = 0;
    }
    
    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _player.GameOver += GameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _startScreen.Close();
        _endGameScreen.UpdateScore(_player.Score);
        _endGameScreen.Open();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
        _startScreen.Close();
        _endGameScreen.Close();
    }
}
