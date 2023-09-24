using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutKniCut : TutModule
{
    void Start()
    {
        
    }

    void Update()
    {
        if (!system.Food)
        {
            Fin();
        }
    }
}
