using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutCatDown : TutModule
{
    void Start()
    {
        Debug.Log("Down");
    }

    void Update()
    {
        if (Input.GetButtonUp("Lbutton"))
        {
            Fin();
        }
    }
}
