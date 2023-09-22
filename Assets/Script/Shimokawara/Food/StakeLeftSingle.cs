using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class StakeLeftSingle : CircleFoodsInterFace
{
    public int FireCnt = 0;
    bool FireFlag;

    public bool isFire;
    public int Number;

    public bool TempClear = false;
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
                        isFire = true;
                        GetComponent<stake_ColorTransfer>().ZeroToOne(0.02f);
                    }
                }

            }
        }
        FireFlag = false;


        if (isFire)
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