using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    List<TutAnim> anims;

    private bool down = false;

    private bool begin = false;
    private ReadIsFade sc;

    void Start()
    {
        sc = GameObject.Find("ReadIsFade").GetComponent<ReadIsFade>();
    }

    void Update()
    {
        if (!begin && !sc.GetIsFade())
        {
            begin = true;
            Time.timeScale = 0;
        }
        else
        {
            if (!down && (Input.GetKey(KeyCode.DownArrow) || Input.GetButton("Submit")))
            {
                TutStart();
            }
            else if (down && Input.GetKeyDown(KeyCode.UpArrow))
            {
                TutEnd();
            }
        }
    }

    private void TutStart()
    {
        down = !down;

        foreach(var anim in anims)
        {
            Time.timeScale = 1;
            anim.Play();
        }
    }

    private void TutEnd()
    {
        down = !down;
        
        foreach(var anim in anims)
        {
            Time.timeScale = 0;
            anim.Replay();
        }
    }
}
