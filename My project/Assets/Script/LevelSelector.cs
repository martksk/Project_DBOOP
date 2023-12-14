using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button[] levelButtons;
    public GameObject[] locks;


    // Start is called before the first frame update
    void Start()
    {
        SetInitialProgressValue();
    }

    void Update()
    {
        UnlockLevels();
    }
    void UnlockLevels()
    {
        // Example: Unlock levels based on the player's progress
        int playerProgress = PlayerPrefs.GetInt("Level", 1);
        // Debug.Log("Player Progress: " + playerProgress);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            // Unlock levels up to the player's progress
            levelButtons[i].interactable = (i + 1 <= playerProgress);
            if(i + 1 <= playerProgress)
            {
            locks[i].SetActive(false);
            }
        }
    }

    void SetInitialProgressValue()
    {
        // Check if the "Level" key exists in PlayerPrefs
        if (!PlayerPrefs.HasKey("Level"))
        {
            // Set the initial value if the key doesn't exist
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.Save();
        }
    }


}
