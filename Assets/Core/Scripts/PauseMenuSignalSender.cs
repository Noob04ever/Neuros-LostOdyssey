using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Runtime.Signals;

public class PauseMenuSignalSender : MonoBehaviour
{
    private bool bIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if(!bIsPaused)
            {
                bIsPaused = true;
                Signal.Send("Music", "Pause");
            }
            else
            {
                bIsPaused = false;
                Signal.Send("Music", "Unpause");
            }
            
        }
    }

    
}
