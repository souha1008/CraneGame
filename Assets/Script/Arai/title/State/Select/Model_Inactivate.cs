using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Inactivate : Object_Activate
{
    private Animator animator;

    [SerializeField] private string animationName;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public override void Method(Select_Object _obj)
    {
        //animator.enabled = false;
        animator.SetFloat("speed", -1);
        animator.Play(animationName, 0, 1);
        _obj.FinishEvent();
    }
}
