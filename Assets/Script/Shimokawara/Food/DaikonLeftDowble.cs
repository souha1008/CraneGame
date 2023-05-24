using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class DaikonLeftDowble : CircleFoodsInterFace
{

    int Cnt = 0;
    void Start()
    {
        m_ChachAction = ChachAction.HARD;
        m_CutAction = CutAction.CAN;//貫通してほしいだけ
        m_HummerAction = HummerAction.SCALE;
        m_FireAction = FireAction.STAY;


        FoodsStart();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        Cnt++;

        if (Cnt > 15)
        {
            //m_CutAction = CutAction.CANNOT;//貫通おわり
            m_FireAction = FireAction.KOGE;
        }

        FoodsFixedUpdate();
    }

    public override void Cut(Collider other)
    {
        if (!isNoAction && isGround)
        {
            float SizeX = transform.localScale.x;

            float Distance = Mathf.Abs(transform.position.x - other.transform.position.x);

            if (Distance < SizeX * 0.25f)
            {
                GameObject Cut1 = (GameObject)Resources.Load("DaikonCenterSingle");
                GameObject Cut2 = (GameObject)Resources.Load("DaikonLeftSingle");

                Vector3 tempPos1 = transform.position;
                Vector3 tempPos2 = transform.position;
                tempPos1.x += 3;//右
                tempPos2.x -= 3;
                // Cubeプレハブを元に、インスタンスを生成、

                Instantiate(Cut1, tempPos1, transform.rotation);
                Cut1.GetComponent<DaikonCenterSingle>().Vel = new Vector3(0.3f, 0.1f, 0);
                Instantiate(Cut2, tempPos2, transform.rotation);
                Cut2.GetComponent<DaikonLeftSingle>().Vel = new Vector3(-0.3f, 0.1f, 0);

                Destroy(gameObject);
            }
            else
            {
                other.GetComponent<Knife>().NotCut();
            }

        }


    }

}