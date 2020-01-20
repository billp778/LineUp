using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int time = 0;
    public Text timer;
    public Text highscore;
    public Health health;

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore") == true)
        {
            highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
        else
        {
            highscore.text = "No High Scores Yet";
        }
        StartTimer();
    }
    
    public void StartTimer()
    {
        time = 0;
        InvokeRepeating("IncrimentTime", 1, 1);
    }

    public void StopTimer()
    {
        CancelInvoke();
        if (PlayerPrefs.GetInt("Highscore") > time || !PlayerPrefs.HasKey("HighScore"))
        {
            SetHighscore();
        }
        SetCurrentTime();
    }

    public void SetCurrentTime()
    {
        PlayerPrefs.SetInt("CurrentTime", time);
    }

    public void SetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", time);
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();

    }

    public void ClearHighscores()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highscore.text = "No High Scores Yet";
    }

    void IncrimentTime()
    {
        time += 1;
        timer.text = "Time: " + time;
    }

    public void GameWon()
    {
        StopTimer();
    }
}