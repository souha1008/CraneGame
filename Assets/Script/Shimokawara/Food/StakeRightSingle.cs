using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class StakeRightSingle : CircleFoodsInterFace
{
    public int FireCnt = 0;
    bool FireFlag;
    bool OldIsFire;
    public bool isFire;
    public int Number;
    public bool TempClear = false;
    StakePlate[] PlateArray;

    public GameObject Effect;
    void Start()
    {
        FoodsStart();
    }
    private void OnEnable()
    {
        PlateArray = GameObject.FindObjectsOfType<StakePlate>();
        Effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        OldIsFire = isFire;

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
                        Debug.Log("Transfar呼び出し  ");
                    }
                }

            }
        }
        FireFlag = false;



        if (isFire)
        {
            Effect.SetActive(true);
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

        if (OldIsFire != isFire)
        {
            SoundManager.instance.SEPlay("肉焼けるSE");
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