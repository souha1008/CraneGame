using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutEx : TutModule
{
    [SerializeField]
    private TutorialManager manager;

    void Start()
    {
        system.NextActivate(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            manager.TutStart();
            system.NextActivate(false);
            CallFin();
            this.enabled = false;
        }
    }
}
