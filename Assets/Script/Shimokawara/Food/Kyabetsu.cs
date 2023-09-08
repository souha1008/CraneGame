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
    public int CutCnt = 0;
    KyabetsuPlate[] PlateArray;
    public GameObject[] ModelArray;
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

        switch (CutCnt)
        {
            case 0:
                ResetModel();
                ModelArray[0].SetActive(true) ;
                break;

            case 1:
            case 2:
                ResetModel();
                ModelArray[1].SetActive(true);
                break;
            
            case 3:
            case 4:
            case 5:
                ResetModel();
                ModelArray[2].SetActive(true);
                break;

            
            case 6:
                ResetModel();
                ModelArray[3].SetActive(true);
                break;
        }


        if (CutCnt >= 6)
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

    void ResetModel()
    {
        for(int i = 0; i < ModelArray.Length;i++)
        {
            ModelArray[i].SetActive(false);
        }
    }
}
