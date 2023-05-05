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
    public int FireCnt = 0;
    bool FireFlag;
    public bool Open = false;

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

        FoodsFixedUpdate();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
            FireFlag = true;
    }
}
