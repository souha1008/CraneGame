using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    List<TutAnim> anims;

    private bool down = false;

    private bool begin = false;
    private ReadIsFade sc;

    private void OnDestroy()
    {
        GameObject.Find("Datas").GetComponent<ScoreData>().SetScore(0, 0);
    }

    void Start()
    {
        sc = GameObject.Find("ReadIsFade").GetComponent<ReadIsFade>();
    }

    void Update()
    {
        if (!begin && !sc.GetIsFade())
        {
            begin = true;

            if (GameObject.Find("TutorialObserver(Clone)").GetComponent<TutorialObserver>().Index == 0)
                Time.timeScale = 0;
        }
    }

    public void TutStart()
    {
        Debug.Log("call play");

        down = !down;
        Time.timeScale = 1;

        foreach(var anim in anims)
        {
            anim.Play();
        }
    }

    public void TutEnd()
    {
        Debug.Log("call replay");

        down = !down;
        Time.timeScale = 0;
        
        foreach(var anim in anims)
        {
            anim.Replay();
        }
    }
}
