using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Hamaguri : CircleFoodsInterFace
{

    HamaguriPlate[] PlateArray;
    public int FireCnt = 0;
    bool FireFlag;
    public bool Open = false;

    void Start()
    {
        FoodsStart();
    }

    private void OnEnable()
    {
        PlateArray = GameObject.FindObjectsOfType<HamaguriPlate>();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        if(!isNoAction)
        {
            if(FireFlag)
            {
                FireCnt++;

                if(FireCnt > 40)
                {
                    m_HummerAction = HummerAction.STAY;
                    Open = true;
                }
            }
            FireFlag = false;
        }

        if(Open )
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
            if (other.GetComponent<Fire>().FireState == FIRE_STATE.FIRE_FIRE)
            {
                FireFlag = true;
            }
        }
          
    }
}
