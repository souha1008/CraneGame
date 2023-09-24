using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutCatButton : TutModule
{
    void Start()
    {
        Time.timeScale = 0;
        system.NextActivate(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            Time.timeScale = 1;
            system.NextActivate(false);
            CallFin();
            this.enabled = false;
        }
    }
}
