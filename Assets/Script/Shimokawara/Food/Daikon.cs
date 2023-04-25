using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Daikon : CircleFoodsInterFace
{
    public GameObject CutDaikon;

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

    public override void Cut(Collider other)
    {
        if(m_CutAction == CutAction.CAN && isGround)
        {
            GameObject Cut1 = (GameObject)Resources.Load("CutDaikon");
            GameObject Cut2 = (GameObject)Resources.Load("CutDaikon");

            Vector3 tempPos1 = transform.position;
            Vector3 tempPos2 = transform.position;
            tempPos1.x -= 2;
            tempPos2.x += 2;
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(Cut1, tempPos1, transform.rotation);
            Cut1.GetComponent<CutDaikon>().Vel = new Vector3(0.3f, 0.1f, 0);
            Instantiate(Cut2, tempPos2, transform.rotation);
            Cut2.GetComponent<CutDaikon>().Vel = new Vector3(-0.3f, 0.1f, 0);
        }

        Destroy(gameObject);
    }



}
