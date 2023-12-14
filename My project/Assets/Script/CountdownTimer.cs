// CountdownTimer.cs

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 180.0f;  // Set your initial countdown time here
    public SceneLoader sl;
    private TMP_Text countdownText;
    private void Start()
    {
        countdownText = GetComponentInChildren<TMP_Text>();
        UpdateTimerText();
        StartCountdown();
    }

    private void UpdateTimerText()
    {
        // Convert countdownTime to minutes and seconds
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);

        // Display the time in the TMP_Text
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void StartCountdown()
    {
        InvokeRepeating("UpdateCountdown", 1f, 1f);
    }

    private void UpdateCountdown()
    {
        if (countdownTime > 0)
        {
            countdownTime -= 1f;
            UpdateTimerText();
        }
        else
        {
            countdownTime = 0f;
            PlayerPrefs.SetInt("Score", ScoreManager.score);
            PlayerPrefs.Save();
            UpdateProgress();
            sl.LoadScene();
            CancelInvoke("UpdateCountdown");
        }
    }

    private void UpdateProgress()
    {
        PlayerPrefs.SetInt("Level", 2);
        PlayerPrefs.Save();
    }

}
