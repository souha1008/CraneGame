using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutHamPress : TutModule
{
    void Start()
    {
        
    }

    void Update()
    {
        if (!system.Food)
        {
            Debug.Log("Pow!");
            Fin();
        }
    }
}
