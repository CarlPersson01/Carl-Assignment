using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settingsMenu;
    private bool _isPaused;

    private void Start()
    {
        _isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
            {
                _pauseMenu.SetActive(true);
                _isPaused = true;
                Time.timeScale = 0f;
            }

            else if (_isPaused)
            {
                _pauseMenu.SetActive(false);
                _settingsMenu.SetActive(false);
                _isPaused = false;
                Time.timeScale = 1f;
            }
        }
    }

    public void gotoMainMenu()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
        Time.timeScale = 1f;
    }

    public void enableSettingsMenu()
    {
        _pauseMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    public void enablePauseMenu()
    {
        _pauseMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }
}
