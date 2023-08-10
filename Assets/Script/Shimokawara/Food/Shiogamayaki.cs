using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Shiogamayaki : CircleFoodsInterFace
{
    public Shio [] ShioArray = new Shio [3];

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
        if(ShioArray[0].HitCnt >= 2 &&
            ShioArray[1].HitCnt >= 2 &&
            ShioArray[2].HitCnt >= 2 )
        {
            isClear = true;
        }

        FoodsFixedUpdate();
    }


}
