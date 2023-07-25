using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutAnim : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private string animname;

    void Start()
    {
        if (!anim) anim = gameObject.GetComponent<Animator>();
    }

    public void Play()
    {
        anim.Play(animname);
    }
}
