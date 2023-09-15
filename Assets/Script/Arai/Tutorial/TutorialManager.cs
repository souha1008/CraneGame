using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    List<TutAnim> anims;

    private bool down = false;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (!down && (Input.GetKey(KeyCode.DownArrow) || Input.GetButton("Submit")))
        {
            down = !down;
            foreach(var anim in anims)
            {
                Time.timeScale = 1;
                anim.Play();
            }
        }
        else if (down && Input.GetKeyDown(KeyCode.UpArrow))
        {
            down = !down;
            foreach(var anim in anims)
            {
                Time.timeScale = 0;
                anim.Replay();
            }
        }
    }
}
