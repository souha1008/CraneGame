using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutKniJuuji : TutModule
{
    void Start()
    {
        
    }

    void Update()
    {
        var x = Input.GetAxis("JuujiKeyX");
        var y = Input.GetAxis("JuujiKeyY");

        if (x != 0 || y != 0)
        {
            Fin();
        }
    }
}
