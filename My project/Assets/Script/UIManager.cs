using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // This method is called when the exit button is clicked
    public void ExitGame()
    {
        // This works for the standalone build of the game
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        // This works in the editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
