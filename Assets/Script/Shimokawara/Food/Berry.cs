using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Berry : CircleFoodsInterFace
{
    public int AirCnt = 0;
    bool AirFlag;
    public bool Dry = false;
    BerryPlate[] PlateArray;

    void Start()
    {
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
        if (!isNoAction)
        {
            if (AirFlag)
            {
                AirCnt++;

                if (AirCnt > 40)
                {
                    m_HummerAction = HummerAction.STAY;
                    Dry = true;
                }
            }
            AirFlag = false;
        }

        if (Dry)
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
        

        FoodsFixedUpdate();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
        {
            if (other.GetComponent<Fire>().FireState == FIRE_STATE.FIRE_AIR)
            {
                AirFlag = true;
            }
        }

    }
}
