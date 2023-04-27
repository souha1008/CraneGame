using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Lemon : CircleFoodsInterFace
{
    public Karaage TarasuObj;

    int Cnt = 0;

    float Size; 

    void Start()
    {
        Size = transform.localScale.x;
        FoodsStart();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();

        if(TarasuObj.isClear)
        {
            isClear = true;
        }
    }

    void FixedUpdate()
    {
        FoodsFixedUpdate();

        Cnt++;


        if(Cnt % 15 == 0)//‚½‚Ü‚ÉLemonn‚½‚ç‚·
        {
            if (Size * 0.75f > transform.localScale.x)
            {
                //Debug.Log("‚Å‚é");

                GameObject LemonJIru = (GameObject)Resources.Load("LemonJIru");
                Instantiate(LemonJIru, transform.position, transform.rotation);

            }
              
        }

    }

}
