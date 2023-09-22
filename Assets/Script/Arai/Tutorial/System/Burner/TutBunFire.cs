using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutBunFire : TutModule
{
    void Start()
    {
        
    }

    void Update()
    {
        if (system.Food.isClear)
        {
            Fin();
        }
    }
}
