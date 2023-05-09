using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Candle : CircleFoodsInterFace
{
    public int FireCnt = 0;
    bool FireAburareFlag;

    public bool isFire = false;

    void Start()
    {
        FoodsStart();
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
            if (FireAburareFlag)
            {
                FireCnt++;

                if (FireCnt > 2)
                {
                    m_HummerAction = HummerAction.STAY;
                    isFire = true;
                }
            }
            FireAburareFlag = false;
        }

        FoodsFixedUpdate();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
            FireAburareFlag = true;
    }
}
