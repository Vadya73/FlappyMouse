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
        _hero.GameOver += OnGameOver;
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _pauseScreen.UnPauseButtonClick += OnUnPauseGame;
        _gameScreen.PauseButtonClick += OnPauseGame;
    }

    private void Awake()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        _hero.GameOver -= OnGameOver;
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
        Debug.Log("Я подписался и работаю!!");
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

    private void OnPauseGame()
    {
        Time.timeScale = 0;
        _pauseScreen.Open();
        _heroMovement.ToggleDashCapability();
        _heroMovement.ToggleJumpCapability();
    }   

    private void OnUnPauseGame()
    {
        Time.timeScale = 1;
        _pauseScreen.Close();
        _heroMovement.ToggleDashCapability();
        _heroMovement.ToggleJumpCapability();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _hero.ResetPlayer();

    }
}