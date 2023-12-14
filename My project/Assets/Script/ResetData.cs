using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    public GameObject[] locks;
    public void OnButtonClick()
    {
        // Set a specific value in PlayerPrefs when the button is clicked
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.Save();
        for (int i=1;i<locks.Length;i++)
        {
            locks[i].SetActive(true);
        }
        // Optionally log for debugging
        Debug.Log("Data has been cleared.");
    }
}
