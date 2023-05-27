using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Inactivate : Object_Activate
{
    [SerializeField] private Animator animator;

    [SerializeField] private string animationName;

    public override void Method(Select_Object _obj)
    {
        //animator.enabled = false;
        animator.SetFloat("speed", -1);
        
        var time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (time > 1) time = 1;

        animator.Play(animationName, 0, time);
        _obj.FinishEvent();
    }
}
