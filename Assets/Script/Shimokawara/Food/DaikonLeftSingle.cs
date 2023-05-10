using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class DaikonLeftSingle : CircleFoodsInterFace
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

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        Cnt++;

        if (Cnt > 15)
        {
            m_CutAction = CutAction.CANNOT;//ŠÑ’Ê‚¨‚í‚è
        }
        if (transform.position.x < ShikiriX)
        {
            isClear = true;
        }
        FoodsFixedUpdate();
    }



}