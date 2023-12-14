using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

            // Pause or resume game logic as needed
            Time.timeScale = (pauseMenuUI.activeSelf) ? 0f : 1f;
        }
    }

    public void ResumeGame()
    {
        if (pauseMenuUI != null)
        {
            // Set the pause menu inactive
            pauseMenuUI.SetActive(false);

            // Resume game logic
            Time.timeScale = 1f;
        }
    }

    public void RestartGame()
    {
        if (pauseMenuUI != null)
        {
            // Set the pause menu inactive
            pauseMenuUI.SetActive(false);

            // Resume game logic
            Time.timeScale = 1f;

            ScoreManager.score = 0;

            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}