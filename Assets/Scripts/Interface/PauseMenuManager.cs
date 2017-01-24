using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour {

    [SerializeField]
    TranslationContainer _translationContainer = null;

    [SerializeField]
    Text _Pause, _ReturnGame;

    [SerializeField]
    GameObject _PausePanel;



	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            if (!_PausePanel.activeInHierarchy)
                SetPause();
            else
                UnSetPause();
        }

        _ReturnGame.text = _translationContainer.getTranslation("BUTTON_RETURN_GAME");
    }

    public void SetPause()
    {
        Time.timeScale = 0;
        _PausePanel.SetActive(true);
    }

    public void UnSetPause()
    {
        Time.timeScale = 1;
        _PausePanel.SetActive(false);
    }
}
