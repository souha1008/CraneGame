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
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void Play()
    {
        Debug.Log("call play");
        anim.SetFloat("Speed", 1);
        anim.Play(animname, 0, 0);
    }

    public void Replay()
    {
        Debug.Log("call replay");
        anim.SetFloat("Speed", -1);
        anim.Play(animname, 0, 1);
    }
}
