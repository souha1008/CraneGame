using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_InactivateEX : Object_Activate
{
    [SerializeField] private Animator[] animator = new Animator[2];

    [SerializeField] private string[] animationName = new string[2];

    public override void Method(Select_Object _obj)
    {
        for(int i = 0; i < 2; ++i)
        {
            animator[i].SetFloat("speed", -1);

            var time = animator[i].GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (time > 1) time = 1;

            animator[i].Play(animationName[i], 0, time);
        }
        _obj.FinishEvent();
    }
}
