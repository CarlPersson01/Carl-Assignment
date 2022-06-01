using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuNav : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCounter;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;

    private void Update()
    {
        if (_scoreCounter == null)
            return;
        else _scoreCounter.text = GameManager.Instance._score.ToString();
    }

    public void gotoMainMenu()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Menu);
    }

    public void startGame()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    public void enableSettingsMenu()
    {
        if (_mainMenu == null || _settingsMenu == null)
            return;

        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    public void enableMainMenu()
    {
        if (_mainMenu == null || _settingsMenu == null)
            return;

        _mainMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }

}
