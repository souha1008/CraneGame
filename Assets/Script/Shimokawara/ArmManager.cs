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
    public CreanHitObj CenterHitObject;

    bool DowbleHitArm = false;

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
        //Vector3 RayStart = (LeftArm.transform.position + RightArm.transform.position) / 2;
        //RayStart.y += 20;


        //if (LeftArm.HitFood && RightArm.HitFood)
        //{
        //    DowbleHitArm = true;
        //}
        //else
        //{
        //    DowbleHitArm = false;
        //}

        //LeftArm.HitFood = false;
        //RightArm.HitFood = false;

        //if(CenterHitObject.Hit)
        //{
        //    DowbleHitArm = true;
        //}
        //else
        //{
        //    DowbleHitArm = false;
        //}
        //CenterHitObject.Hit = false;

        LeftArm.custumFixedUpdate(ArmStickType , CenterHitObject.Move);
        RightArm.custumFixedUpdate(ArmStickType, CenterHitObject.Move);

        CenterHitObject.Move = ARM_MOVE.MOVE;

    }
}
