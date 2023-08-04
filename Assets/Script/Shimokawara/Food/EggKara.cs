using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class EggKara : CircleFoodsInterFace
{

    void Start()
    {


        FoodsStart();
    }
    private void OnEnable()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //if(LeftArmBord == null)
        //{
        //    LeftArmBord = GameObject.Find("ArmBord1");
        //}

        FoodsUpdate();
    }

    void FixedUpdate()
    {
        

        FoodsFixedUpdate();
    }



}