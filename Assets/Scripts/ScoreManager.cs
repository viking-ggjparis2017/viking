﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    int Player_1_Score = 0;
    int Player_2_Score = 0;

    [SerializeField]
    Text Player01, Player02;

    [SerializeField]
    int neededScore = 1;

    [SerializeField]
    GameObject finalScorePanel;

    bool AlreadyWon = false;

    void Start() {
        UpdatePlayerScore();
    }

    void Update() { }

    public void IncrementPlayer01Score()
    {
        ++Player_1_Score;
        UpdatePlayerScore();
        CheckVictory();
    }

    public void IncrementPlayer02Score()
    {
        ++Player_2_Score;
        UpdatePlayerScore();
        CheckVictory();
    }

    void UpdatePlayerScore()
    {
        Player01.text = "Player 01" + "\n" + "Score: " + Player_1_Score.ToString();
        Player02.text = "Player 02" + "\n" + "Score: " + Player_2_Score.ToString();
    }

    void CheckVictory()
    {

        if (!AlreadyWon)
        {
            if (Player_1_Score == neededScore)
            {
                ShowScoreCanvas(1);
            }
            else if (Player_2_Score == neededScore)
            {
                ShowScoreCanvas(2);
            }
        }
    }

    void ShowScoreCanvas(int playerWhoWon)
    {
        print(playerWhoWon);
        
        StartCoroutine(Scale());

        Player01.gameObject.SetActive(false);
        Player02.gameObject.SetActive(false);

        finalScorePanel.SetActive(true);

        Text playerVictory = finalScorePanel.transform.GetChild(0).GetComponent<Text>();
        if (playerWhoWon == 1)
            playerVictory.text = "Player 01" + "\n" + "Victory !";
        else if(playerWhoWon == 2)
            playerVictory.text = "Player 02" + "\n" + "Victory !";
    }
    
    IEnumerator Scale()
    {
        print(Time.timeScale);

        while (Time.timeScale != 0.0f)
        {
            float timeRedution = 0.4f;

            if (Time.timeScale - timeRedution < 0.0f)
                Time.timeScale = 0.0f;
            else
                Time.timeScale -= timeRedution;

            yield return new WaitForSeconds(0.5f);
        }

        //yield return new WaitForSeconds(waitTime);

    }
}