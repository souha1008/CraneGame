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

    public GameObject Effect;
    void Start()
    {
        FoodsStart();
        Effect.SetActive(false);
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

        if(isFire)
        {
            Effect.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
            FireAburareFlag = true;
    }
}
