using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StarActive : MonoBehaviour
{
    public GameObject[] stars;
    public TMP_Text scoreText;

    public int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);

        // Display the score
        scoreText.text = score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if(score >= 10 && score < 15)
        {
            stars[0].SetActive(true);
        }
        if(score >= 15 && score < 21)
        {
            stars[0].SetActive(true);
            stars[2].SetActive(true);
        }
        if(score >= 21 && score < 31)
        {
            stars[0].SetActive(true);
            stars[2].SetActive(true);
            stars[1].SetActive(true);
        }
    }
}
