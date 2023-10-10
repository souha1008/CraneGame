using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutFin : TutModule
{
    void Start()
    {
        system.FinishActivate(true);
        Destroy(GameObject.Find("TutorialObserver(Clone)").gameObject);
    }

    void Update()
    {
        
    }
}
