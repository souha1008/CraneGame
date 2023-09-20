using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class CutSuica : CircleFoodsInterFace
{

    int Cnt = 0;
    BerryPlate[] PlateArray;
    void Start()
    {
        m_ChachAction = ChachAction.HARD;
        m_CutAction = CutAction.CAN;//�ђʂ��Ăق�������
        m_HummerAction = HummerAction.SCALE;
        m_FireAction = FireAction.STAY;


        FoodsStart();
    }

    private void OnEnable()
    {
        PlateArray = GameObject.FindObjectsOfType<BerryPlate>();
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
            m_CutAction = CutAction.CANNOT;//�ђʂ����
            m_FireAction = FireAction.KOGE;
        }

        for (int i = 0; i < PlateArray.Length; i++)
        {
            if (PlateArray[i])
            {
                float VectorLength = (transform.position - PlateArray[i].transform.position).magnitude;
                if (VectorLength < 8)
                {
                    isClear = true;
                }
            }
        }

        FoodsFixedUpdate();
    }



}