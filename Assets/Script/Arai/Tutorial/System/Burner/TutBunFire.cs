using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutBunFire : TutModule
{
    private bool once = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (!once && system.Food.isClear)
        {
            once = true;
            StartCoroutine(MoveToDrier());
        }
    }

    private IEnumerator MoveToDrier()
    {
        Fin();
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(waittime);

        SceneManager.LoadScene("Tutrial05");
        Time.timeScale = 1;

        yield break;
    }
}
