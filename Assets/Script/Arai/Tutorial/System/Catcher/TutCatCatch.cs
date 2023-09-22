using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutCatCatch : TutModule
{
    [SerializeField]
    private TutorialManager manager;

    private bool wait = false;

    void Start()
    {
        manager.TutEnd();
        StartCoroutine(Wait());
    }

    void Update()
    {
        if (wait && Input.GetKey(KeyCode.I))
        {
            manager.TutStart();
            Fin();
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2.5f);

        wait = true;

        yield break;
    }
}
