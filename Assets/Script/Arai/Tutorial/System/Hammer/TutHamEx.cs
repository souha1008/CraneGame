using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutHamEx : TutModule
{
    void Start()
    {
        system.NextActivate(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetButton("Submit"))
        {
            system.NextActivate(false);
            CallFin();
            this.enabled = false;
        }
    }
}
