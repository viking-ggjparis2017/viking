using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchGameButton : MonoBehaviour {
    private const string GAME_SCENE = "MainScene";

    [SerializeField]
    TranslationContainer _translationContainer = null;

    [SerializeField]
    Text _text = null;

	// Update is called once per frame
	public void Update ()
    {
        _text.text = _translationContainer.getTranslation("BUTTON_START_GAME");
	}

    public void StartGame()
    {
        SceneManager.LoadScene(LaunchGameButton.GAME_SCENE);
    }
}
