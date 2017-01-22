using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryMenuManager : MonoBehaviour {
    private const string MENU_SCENE = "StartScreen";

    [SerializeField]
    Text _restartText, _returnMainMenuText = null;

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(VictoryMenuManager.MENU_SCENE);
    }

    public void RestartLevel()
    {
        gameObject.SetActive(false);
        ScoreManager.Instance.ResetScene(true);
    }
}
