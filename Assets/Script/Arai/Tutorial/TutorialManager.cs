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
        
    }

    void Update()
    {
        if (!down && (Input.GetKey(KeyCode.DownArrow) || Input.GetButton("Submit")))
        {
            down = !down;
            foreach(var anim in anims)
            {
                anim.Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            foreach(var anim in anims)
            {
                anim.Replay();
            }
        }
    }
}
