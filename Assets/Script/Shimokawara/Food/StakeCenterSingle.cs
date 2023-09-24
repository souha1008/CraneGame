using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class StakeCenterSingle : CircleFoodsInterFace
{

    public int FireCnt = 0;
    bool FireFlag;

    public bool isFire = false;
    public int Number;

    StakePlate[] PlateArray;

    void Start()
    {
        FoodsStart();
    }

    private void OnEnable()
    {
        
        PlateArray = GameObject.FindObjectsOfType<StakePlate>();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        if (!isFire)
        {
            if (!isNoAction)
            {
                if (FireFlag)
                {
                    FireCnt++;

                    if (FireCnt > 10)
                    {
                        GetComponent<stake_ColorTransfer>().ZeroToOne(0.02f);
                        isFire = true;
                    }
                }

            }
        }
        FireFlag = false;





        //クリア処理
        StakeLeftSingle[] LeftArray;
        LeftArray = GameObject.FindObjectsOfType<StakeLeftSingle>();
        StakeLeftSingle ParingLeft = null;
        for (int i = 0; i < LeftArray.Length; i++)
        {
            if (LeftArray[i])
            {
                if (LeftArray[i].Number == Number && LeftArray[i].TempClear)
                {
                    ParingLeft = LeftArray[i];
                }
            }
        }

        StakeRightSingle[] RightArray;
        RightArray = GameObject.FindObjectsOfType<StakeRightSingle>();
        StakeRightSingle ParingRight = null;
        for (int i = 0; i < RightArray.Length; i++)
        {
            if (RightArray[i])
            {
                if (RightArray[i].Number == Number && RightArray[i].TempClear)
                {
                    ParingRight = RightArray[i];
                }
            }
        }


        //もしペアリングに成功すれば
        bool TempClear = false;
        if (isFire && ParingLeft && ParingRight)
        {
            for (int i = 0; i < PlateArray.Length; i++)
            {
                if (PlateArray[i])
                {
                    float VectorLength = (transform.position - PlateArray[i].transform.position).magnitude;
                    if (VectorLength < 8)
                    {
                        TempClear = true;
                    }
                }
            }
        }

        isClear = TempClear;


        FoodsFixedUpdate();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
        {
            if (other.GetComponent<Fire>().FireState == FIRE_STATE.FIRE_FIRE)
            {
                FireFlag = true;
            }
        }

    }
}