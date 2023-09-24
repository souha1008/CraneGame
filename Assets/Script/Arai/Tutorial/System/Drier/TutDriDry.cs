using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutDriDry : TutModule
{
    void Start()
    {
        
    }

    void Update()
    {
        Berry food = (Berry)system.Food;

        if (food.Dry)
        {
            Fin();
        }
    }
}
