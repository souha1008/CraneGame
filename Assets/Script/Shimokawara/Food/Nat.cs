using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Nat : CircleFoodsInterFace
{
    public GameObject MotoRyouri;
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

        //float VectorLength = (transform.position - MotoRyouri.transform.position).magnitude;
        //if(VectorLength < 7)
        //{
        //    isClear = false;
        //}
        //else
        //{
        //    isClear = true;
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        //if(other == MotoRyouri)
        //{

        //}
    }

    //public override void Hummer(Collider other)
    //{


    //}
}


