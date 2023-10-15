using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Mochi : CircleFoodsInterFace
{
    Usu[] UsuArray;
    MochiPlate[] PlateArray;
    int HummerCnt = 0;
    int OldHummerCnt = 0;
    private void OnEnable()
    {
        UsuArray = GameObject.FindObjectsOfType<Usu>();
        PlateArray = GameObject.FindObjectsOfType<MochiPlate>();
        GetComponent<General_ColorTransfer>().SetParm(0f);
    }

    void Start()
    {
        HummerCnt = 0;
        FoodsStart();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        OldHummerCnt = HummerCnt;

        FoodsFixedUpdate();

        if (HummerCnt == 1)
            GetComponent<General_ColorTransfer>().SetParm(0.33f);
        else if (HummerCnt == 2)
            GetComponent<General_ColorTransfer>().SetParm(0.66f);
        else if(HummerCnt >= 3)
            GetComponent<General_ColorTransfer>().SetParm(1.0f);

        if (HummerCnt >= 3)
        {
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
        }

        if(OldHummerCnt != HummerCnt)
        {
            if(HummerCnt <= 3)
            {
                SoundManager.instance.SEPlay("–Ý‚Â‚«SE");
            }
        }

    }

    public override void Hummer(Collider other)
    {
        for (int i = 0; i < UsuArray.Length; i++)
        {
            if (UsuArray[i])
            {
                float VectorLength = (transform.position - UsuArray[i].transform.position).magnitude;
                if (VectorLength < 8)
                {
                    HummerCnt++;
                }
            }
        }
    }
}
