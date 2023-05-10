using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class KurumiNakami : CircleFoodsInterFace
{

    int Cnt = 0;
    void Start()
    {
        m_ChachAction = ChachAction.HARD;
        m_CutAction = CutAction.CANNOT;
        m_HummerAction = HummerAction.STAY;//ŠÑ’Ê‚µ‚Ä‚Ù‚µ‚¢‚¾‚¯
        m_FireAction = FireAction.STAY;


        FoodsStart();

        Vel = new Vector3(0.15f, 0.14f, 0);
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
            m_HummerAction = HummerAction.SCALE;//ŠÑ’Ê‚µ‚Ä‚Ù‚µ‚¢‚¾‚¯
        }

        FoodsFixedUpdate();
    }



}