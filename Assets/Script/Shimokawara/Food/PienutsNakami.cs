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
    NutsPlate[] PlateArray;
    int Cnt = 0;
    void Start()
    {
        m_ChachAction = ChachAction.HARD;
        m_CutAction = CutAction.CANNOT;
        m_HummerAction = HummerAction.STAY;//ŠÑ’Ê‚µ‚Ä‚Ù‚µ‚¢‚¾‚¯
        m_FireAction = FireAction.STAY;


        FoodsStart();
    }

    private void OnEnable()
    {
        PlateArray = GameObject.FindObjectsOfType<NutsPlate>();
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