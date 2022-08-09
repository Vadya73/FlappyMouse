using Assets.Scripts.UI;
using Scripts.Hero;
using Scripts.Obstacles;
using Scripts.UI;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private ObstacleGenerator _obstacleGenerator;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameScreen _gameScreen;

    private void OnEnable()
    {
        _hero.GameOver += OnGameOver;
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _hero.GameOver -= OnGameOver;
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _obstacleGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _hero.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
    //public void TogglePauseCanvas()
    //{
    //    _pauseScreen.SetActive(!_pauseScreen.activeSelf);

    //    if (_pauseScreen.activeSelf)
    //    {
    //        Time.timeScale = 0f;
    //        _gameScreen.SetActive(false);
    //    }
    //    else
    //    {
    //        _gameScreen.SetActive(true);
    //        Time.timeScale = 1f;
    //    }
    //}
}