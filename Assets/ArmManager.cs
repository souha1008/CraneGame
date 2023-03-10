using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmManager : MonoBehaviour
{
    public enum ARM_STICK_TYPE
    {
        OOKUMA_KIMOI,
        AKIYAMA_HANGETSU,
        BUTTON_PUSH,
        RIGHT_STICK_UPDOWN,
        RIGHT_STICK_CENTER_DOWN
    }

    public ARM_STICK_TYPE ArmStickType;
    public Arm LeftArm;
    public Arm RightArm;

    // Start is called before the first frame update
    void Start()
    {
        LeftArm.custumStart(1);
        RightArm.custumStart(-1);
    }

    // Update is called once per frame
    void Update()
    {
        LeftArm.custumUpdate();
        RightArm.custumUpdate();
    }

    void FixedUpdate()
    {
        LeftArm.custumFixedUpdate(ArmStickType);
        RightArm.custumFixedUpdate(ArmStickType);
    }
}
