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

    private void OnEnable()
    {
        UsuArray = GameObject.FindObjectsOfType<Usu>();
        PlateArray = GameObject.FindObjectsOfType<MochiPlate>();   
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
        FoodsFixedUpdate();

        if(HummerCnt >= 3)
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
