using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class CutTomato : CircleFoodsInterFace
{

    int Cnt = 0;
    void Start()
    {
        m_ChachAction = ChachAction.HARD;
        m_CutAction = CutAction.CAN;//ŠÑ’Ê‚µ‚Ä‚Ù‚µ‚¢‚¾‚¯
        m_HummerAction = HummerAction.SCALE;
        m_FireAction = FireAction.STAY;


        FoodsStart();
    }
    //private void OnEnable()
    //{
    //    m_ChachAction = ChachAction.HARD;
    //    m_CutAction = CutAction.CAN;//ŠÑ’Ê‚µ‚Ä‚Ù‚µ‚¢‚¾‚¯
    //    m_HummerAction = HummerAction.SCALE;
    //    m_FireAction = FireAction.STAY;


    //    FoodsStart();
    //}


    // Update is called once per frame
    void Update()
    {
        //if(LeftArmBord == null)
        //{
        //    LeftArmBord = GameObject.Find("ArmBord1");
        //}

        FoodsUpdate();
    }

    void FixedUpdate()
    {
        Cnt++;

        if (Cnt > 15)
        {
            m_CutAction = CutAction.CANNOT;//ŠÑ’Ê‚¨‚í‚è
            m_FireAction = FireAction.KOGE;
        }
        if (transform.position.x < ShikiriX)
        {
            isClear = true;
        }
        FoodsFixedUpdate();
    }



}