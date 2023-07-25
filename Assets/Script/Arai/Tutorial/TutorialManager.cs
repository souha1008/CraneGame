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
        if (Input.anyKey)
        {
            foreach(var anim in anims)
            {
                anim.Play();
            }
        }
    }
}
