using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Kyabetsu: CircleFoodsInterFace
{
    int CutCnt = 0;
    KyabetsuPlate[] PlateArray;

    void Start()
    {
        CutCnt = 0;
        FoodsStart();


    }
    private void OnEnable()
    {
        PlateArray = GameObject.FindObjectsOfType<KyabetsuPlate>();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        FoodsFixedUpdate();

        if(CutCnt >= 6)
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

    public override void Cut(Collider other)
    {
        if (!isNoAction /*&& isGround*/)
        {
            CutCnt++;
        }
    }
}
