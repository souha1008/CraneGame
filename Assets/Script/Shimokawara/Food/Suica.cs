using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Suica: CircleFoodsInterFace
{

    float Angle = 0;
    float MAX_ANGLE  = 60;
    float MIN_ANGLE  = -60;
    float AngleVel = 0;
    float OldAngle = 0;

    float Size;

    void Start()
    {
        Size = transform.localScale.x;

        AngleVel = 1;
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

        if (!isNoAction)
        {
            if (isGround)
            {
                OldAngle = Angle;

                Angle += AngleVel;
                if (Angle > MAX_ANGLE)
                {
                    Angle = MAX_ANGLE;
                    AngleVel = -1;
                }
                if (Angle < MIN_ANGLE)
                {
                    Angle = MIN_ANGLE;
                    AngleVel = 1;
                }


                float VelX = (OldAngle - Angle) / 360 * Size * Mathf.PI;

                transform.position = new Vector3(transform.position.x + VelX, transform.position.y, transform.position.z);
            }

            transform.eulerAngles = new Vector3(0, 0, Angle);
        }
       
      
    }

    public override void Cut(Collider other)
    {
        if (m_CutAction == CutAction.CAN && isGround)
        {
            float SizeX = transform.localScale.x;

            float Distance = Mathf.Abs(transform.position.x - other.transform.position.x);

            if (Distance < SizeX * 0.25f && Mathf.Abs(Angle) < 20)
            {
                GameObject Cut1 = (GameObject)Resources.Load("CutSuica");
                GameObject Cut2 = (GameObject)Resources.Load("CutSuica");

                Vector3 tempPos1 = transform.position;
                Vector3 tempPos2 = transform.position;
                tempPos1.x += 3;//右
                tempPos2.x -= 3;
                // Cubeプレハブを元に、インスタンスを生成、

                Instantiate(Cut1, tempPos1, Quaternion.Euler(0f, 0f, 0.0f));
                Cut1.GetComponent<CutSuica>().Vel = new Vector3(-0.3f, 0.1f, 0);
                Instantiate(Cut2, tempPos2, Quaternion.Euler(0f, 180f, 0.0f));
                Cut2.GetComponent<CutSuica>().Vel = new Vector3(0.3f, 0.1f, 0);

                Destroy(gameObject);
            }
            else
            {
                other.GetComponent<Knife>().NotCut();
            }

        }


    }



}
