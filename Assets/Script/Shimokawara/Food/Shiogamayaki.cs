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
    public GameObject[] Model = new GameObject[3];

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
        if(ShioArray[0].HitCnt >= 1 &&
            ShioArray[1].HitCnt >= 1 &&
            ShioArray[2].HitCnt >= 1 )
        {
            isClear = true;
        }

        for(int i = 0; i < 3; i++)
        {
            if (ShioArray[i].HitCnt >= 1)
            {
                Model[i].gameObject.SetActive(false);
            }
        }
        

        FoodsFixedUpdate();
    }


}
