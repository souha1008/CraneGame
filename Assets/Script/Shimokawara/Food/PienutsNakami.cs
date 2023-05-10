using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class PienutsNakami : CircleFoodsInterFace
{

    int Cnt = 0;
    void Start()
    {
        m_ChachAction = ChachAction.HARD;
        m_CutAction = CutAction.CANNOT;
        m_HummerAction = HummerAction.STAY;//貫通してほしいだけ
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
            m_HummerAction = HummerAction.SCALE;//貫通してほしいだけ
        }

        FoodsFixedUpdate();
    }



}