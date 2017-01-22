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
    Text _LaunchText, _OptionText, _CreditsText, _ExitText = null;

    // Update is called once per frame
    public void Update()
    {
        _LaunchText.text = _translationContainer.getTranslation("BUTTON_START_GAME");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(MainMenuManager.GAME_SCENE);
    }
    
}
