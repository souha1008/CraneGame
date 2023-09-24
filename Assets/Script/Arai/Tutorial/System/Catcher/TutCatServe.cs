using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutCatServe : TutModule
{
    private CircleFoodsInterFace food;

    void Start()
    {
        food = system.Food;
    }

    void Update()
    {
        if (food.isClear == true)
        {
            Fin();
        }
    }
}
