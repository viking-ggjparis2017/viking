using UnityEngine;
using System.Collections;

public class SoundMode : MonoBehaviour {

    [SerializeField]
    private AudioSource sound1;
    [SerializeField]
    private AudioSource sound2;
    [SerializeField]
    private AudioSource sound3;
    [SerializeField]
    private AudioSource victory;

    public void UpdateScore(int score)
    {
        if(score > 0 && sound2.mute)
        {
            sound2.mute = false;
        }

        if(score >= 4 && sound3.mute)
        {
            sound3.mute = false;
        }
    }

    public void GameEnd()
    {
        sound1.Stop();
        sound2.Stop();
        sound3.Stop();
        victory.Play();
    }

    public void ResetGame()
    {
        sound1.Play();
        sound2.Play();
        sound2.mute = true;
        sound3.Play();
        sound2.mute = true;
        victory.Stop();
    }
}
