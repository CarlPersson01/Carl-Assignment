using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _level;

    public int _score = 0;
    public int _playerLives;

    [SerializeField] private GameObject _ball;

    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            case GameState.Finished:
                HandleFinished();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void HandlePlaying()
    {
        NewGame();
    }

    private void HandleGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void HandleFinished()
    {

    }

    private void NewGame()
    {
        this._score = 0;
        this._playerLives = 3;

        LoadLevel(1);

        Invoke(nameof(BallSpawn), 0.2f);
    }

    private void LoadLevel(int level)
    {
        this._level = level;

        SceneManager.LoadScene("Level" + level);
    }

    public void AddScore(BrickScript brick)
    {
        this._score += brick._pointValue;
    }

    public void LooseLife(BoundsScript Bounds)
    {
        this._playerLives -= Bounds._damageToGive;
        SoundManager.Instance.Play(SettingsHolder.Instance._miss);
        if (_playerLives < 0)
        {
            UpdateGameState(GameState.GameOver);
            SoundManager.Instance.Play(SettingsHolder.Instance._loose);
        }
            
    }

    private void BallSpawn()
    {
        Instantiate(_ball, Vector2.zero, Quaternion.identity);
    }

    public enum GameState
    {
        Menu,
        Playing,
        GameOver,
        Finished
    }
}
