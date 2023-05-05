using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Tomato : CircleFoodsInterFace
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

    public override void Cut(Collider other)
    {
        if (m_CutAction == CutAction.CAN && isGround)
        {
            float SizeX = transform.localScale.x;
            Debug.Log(SizeX);

            float Distance = Mathf.Abs(transform.position.x - other.transform.position.x);

            if(Distance< SizeX * 0.25f)
            {
                GameObject Cut1 = (GameObject)Resources.Load("CutTomato");
                GameObject Cut2 = (GameObject)Resources.Load("CutTomato");

                Vector3 tempPos1 = transform.position;
                Vector3 tempPos2 = transform.position;
                tempPos1.x += 3;//右
                tempPos2.x -= 3;
                // Cubeプレハブを元に、インスタンスを生成、
                
                Instantiate(Cut1, tempPos1, transform.rotation);
                Cut1.GetComponent<CutTomato>().Vel = new Vector3(-0.3f, 0.1f, 0);
                Instantiate(Cut2, tempPos2, Quaternion.Euler(0f, 180f, 0.0f));
                Cut2.GetComponent<CutTomato>().Vel = new Vector3(0.3f, 0.1f, 0);

                Destroy(gameObject);
            }
            else
            {
                other.GetComponent<Knife>().NotCut();
            }
            
        }

        
    }



}
