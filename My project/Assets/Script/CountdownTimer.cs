// CountdownTimer.cs

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f;  // Set your initial countdown time here
    public SceneLoader sl;
    private Text countdownText;

    private void Start()
    {
        countdownText = GetComponentInChildren<Text>();
        UpdateTimerText();
        StartCountdown();
    }

    private void UpdateTimerText()
    {
        countdownText.text = Mathf.Ceil(countdownTime).ToString();
    }

    private void StartCountdown()
    {
        InvokeRepeating("UpdateCountdown", 1f, 1f);
    }

    private void UpdateCountdown()
    {

        countdownTime -= 1f;

        if (countdownTime <= 0f)
        {
            countdownTime = 0f;
            sl.LoadScene();
        }
        UpdateTimerText();
        
    }
}
