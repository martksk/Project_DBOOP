using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isGamePaused = false;
    void Start()
    {
        ResumeGame();
        // Hide the cursor at the beginning of the game
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
        }
    }

    // public void TogglePauseMenu()
    // {
    //     if (pauseMenuUI != null)
    //     {
    //         pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

    //         // Pause or resume game logic as needed
    //         Time.timeScale = (pauseMenuUI.activeSelf) ? 0f : 1f;
    //     }
    // }

    // public void TogglePauseMenu()
    // {
    //     if (pauseMenuUI != null)
    //     {
    //         // Toggle the visibility of the pause menu
    //         pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

    //         // Toggle the cursor visibility based on the pause menu's visibility
    //         Cursor.visible = pauseMenuUI.activeSelf;

    //         // Pause or resume game logic as needed
    //         Time.timeScale = (pauseMenuUI.activeSelf) ? 0f : 1f;

    //         // Lock or unlock the cursor based on the pause menu's visibility
    //         Cursor.lockState = (pauseMenuUI.activeSelf) ? CursorLockMode.None : CursorLockMode.Locked;
    //     }
    // }

    void PauseGame()
    {
        // Set the pause menu to be active
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);

            // Pause the game
            Time.timeScale = 0f;

            // Set cursor visibility and lock state based on the pause menu's visibility
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Update the pause state
            isGamePaused = true;
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

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            isGamePaused = false;
        }
    }

    public void RestartGame()
    {
        if (pauseMenuUI != null)
        {
            // Set the pause menu inactive
            pauseMenuUI.SetActive(false);
            isGamePaused = false;

            // Resume game logic
            Time.timeScale = 1f;

            ScoreManager.score = 0;

            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}