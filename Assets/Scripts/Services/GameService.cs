using Assets.Scripts.UI;
using Scripts.Hero;
using Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameService : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private HeroMovement _heroMovement;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameScreen _gameScreen;

    [SerializeField] private string _menuSceneName = "MainMenu";
    [SerializeField] private string _sceneToLoad;

    
    private void OnEnable()
    {
        Hero.OnGameOvered += OnGameOver; //use static Action example
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _pauseScreen.UnPauseButtonClick += OnUnPauseGame;
        _gameScreen.PauseButtonClick += OnPauseGame;
    }
    
    private void OnDisable()
    {
        Hero.OnGameOvered -= OnGameOver;
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _pauseScreen.UnPauseButtonClick -= OnUnPauseGame;
        _gameScreen.PauseButtonClick -= OnPauseGame;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _gameScreen.Open();
        StartGame();
        _heroMovement.ToggleDashCapability();
        _heroMovement.ToggleJumpCapability();
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnGameOver()
    {
        _gameOverScreen.Open();
        Time.timeScale = 0;
        _heroMovement.ToggleDashCapability();
        _heroMovement.ToggleJumpCapability();
        _gameScreen.Close();
    }

    private void OnPauseGame()
    {
        Time.timeScale = 0;
        _pauseScreen.Open();
        _heroMovement.ToggleDashCapability();
        _heroMovement.ToggleJumpCapability();
        _gameScreen.Close();
    }   

    private void OnUnPauseGame()
    {
        Time.timeScale = 1;
        _pauseScreen.Close();
        _heroMovement.ToggleDashCapability();
        _heroMovement.ToggleJumpCapability();
        _gameScreen.Open();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _hero.ResetPlayer();
    }
}