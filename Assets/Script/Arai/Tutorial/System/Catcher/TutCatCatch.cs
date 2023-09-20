using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutCatCatch : TutModule
{
    private int cnt = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if ((++cnt) >= 60)
        {
            Fin();
        }
    }
}
