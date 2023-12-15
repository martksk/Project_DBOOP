using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceEnd : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            CountdownTimer.countdownTime = 0f;
        }
    }

}
