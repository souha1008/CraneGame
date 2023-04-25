using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Kurumi : CircleFoodsInterFace
{

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
        FoodsFixedUpdate();
    }

    public override void Hummer(Collider other)
    {
        if(!isClear)
        {
            isClear = true;

            m_HummerAction = HummerAction.STAY;
        }
        


    }


}
