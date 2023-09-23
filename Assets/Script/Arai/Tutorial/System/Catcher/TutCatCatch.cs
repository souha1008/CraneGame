using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutCatCatch : TutModule
{
    [SerializeField]
    private TutorialManager manager;

    private bool wait = false;

    [SerializeField]
    private GameObject tutcanvas;

    private PointerCatcher pointer;

    void Start()
    {
        manager.TutEnd();
        StartCoroutine(Wait());
    }

    void Update()
    {
        if (wait && pointer.Clear)
        {
            Destroy(pointer.transform.parent.gameObject);
            Fin(manager);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2.5f);

        GameObject obj = Instantiate(tutcanvas, transform.parent);

        var pointers = obj.GetComponentsInChildren<PointerCatcher>();

        foreach(var pointa in pointers)
        {
            if (pointa)
            {
                pointer = pointa;
                break;
            }
        }

        wait = true;

        yield break;
    }
}
