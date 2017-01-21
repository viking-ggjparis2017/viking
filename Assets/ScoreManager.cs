using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    int Player_1_Score = 0;
    int Player_2_Score = 0;

    [SerializeField]
    Text Player01, Player02;

    void Start () {
        UpdatePlayerScore();
    }
	
	void Update () {}

    void IncrementPlayer01Score()
    {
        ++Player_1_Score;
        UpdatePlayerScore();
    }

    void IncrementPlayer02Score()
    {
        ++Player_2_Score;
        UpdatePlayerScore();
    }

    void UpdatePlayerScore()
    {
        Player01.text = "Player 01" + "\n" + "Score: " + Player_1_Score.ToString();
        Player02.text = "Player 02" + "\n" + "Score: " + Player_2_Score.ToString();
    }

}
