using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    private const string GAME_SCENE = "MainScene";

    [SerializeField]
    TranslationContainer _translationContainer = null;

    [SerializeField]
    Text _LaunchText, _HelpText, _CreditsText, _ExitText = null;

    [SerializeField]
    GameObject _Buttons, _HelpPanel;

    // Update is called once per frame
    public void Update()
    {
        _LaunchText.text = _translationContainer.getTranslation("BUTTON_START_GAME");
        _HelpText.text = _translationContainer.getTranslation("BUTTON_HELP_PANEL");
        _ExitText.text = _translationContainer.getTranslation("BUTTON_EXIT_GAME");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(MainMenuManager.GAME_SCENE);
    }

    public void OpenHelpPanel()
    {
        _Buttons.SetActive(false);
        _HelpPanel.SetActive(true);
    }

    public void ReturnToMenu()
    {
        _Buttons.SetActive(true);
        _HelpPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
