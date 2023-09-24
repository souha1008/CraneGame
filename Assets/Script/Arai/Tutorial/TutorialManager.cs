using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    List<TutAnim> anims;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
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
