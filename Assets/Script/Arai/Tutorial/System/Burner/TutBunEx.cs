using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutBunEx : TutModule
{
    void Start()
    {
        system.NextActivate(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown("joystick button 1"))
        {
            system.NextActivate(false);
            CallFin();
            this.enabled = false;
        }
    }
}
