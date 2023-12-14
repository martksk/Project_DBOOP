using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDataOnClick : MonoBehaviour
{
    public void AddPoints(int pointsToAdd)
    {
        // Get the current score from PlayerPrefs
        int currentProgress = PlayerPrefs.GetInt("Level", 1);

        // Add the new points
        currentProgress += 1;

        // Save the updated score back to PlayerPrefs
        PlayerPrefs.SetInt("Level", currentProgress);
        PlayerPrefs.Save();

        // Log for debugging
        Debug.Log("Data add.");
    }
}
