using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Activate : Object_Activate
{
    private Animator animator;

    [SerializeField] private string animationName;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetFloat("speed", -1);
        animator.Play(animationName, 0, 0);
    }
    
    public override void Method(Select_Object _obj)
    {
        animator.SetFloat("speed", 1);
        
        var time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (time < 0) time = 0;

        animator.Play(animationName, 0, time);
        _obj.FinishEvent();
    }
}
