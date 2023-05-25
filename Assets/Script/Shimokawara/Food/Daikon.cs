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
        if(!isNoAction && isGround)
        {
            float SizeX = transform.localScale.x;

            float X_Vector= (other.transform.position.x - transform.position.x);

            if(X_Vector > SizeX / 12 && X_Vector < SizeX / 12 * 4)
            {
                GameObject Cut1 = (GameObject)Resources.Load("DaikonLeftDowble");
                GameObject Cut2 = (GameObject)Resources.Load("DaikonRightSingle");

                Vector3 tempPos1 = transform.position;
                Vector3 tempPos2 = transform.position;
                tempPos1.x -= 3;
                tempPos2.x += 3;//右
                                // Cubeプレハブを元に、インスタンスを生成、
                Instantiate(Cut1, tempPos1, transform.rotation);
                Cut1.GetComponent<DaikonLeftDowble>().Vel = new Vector3(-0.3f, 0.1f, 0);
                Instantiate(Cut2, tempPos2, transform.rotation);
                Cut2.GetComponent<DaikonRightSingle>().Vel = new Vector3(0.3f, 0.1f, 0);

                SoundManager.instance.SEPlay("おもちゃ切断SE");

                Destroy(gameObject);

                Debug.Log("右切");
            }

            else if (X_Vector < -SizeX / 12 && X_Vector > - SizeX / 12 * 4)
            {

                GameObject Cut1 = (GameObject)Resources.Load("DaikonLeftSingle");
                GameObject Cut2 = (GameObject)Resources.Load("DaikonRightDowble");

                Vector3 tempPos1 = transform.position;
                Vector3 tempPos2 = transform.position;
                tempPos1.x -= 3;
                tempPos2.x += 3;//右
                                // Cubeプレハブを元に、インスタンスを生成、
                Instantiate(Cut1, tempPos1, transform.rotation);
                Cut1.GetComponent<DaikonLeftSingle>().Vel = new Vector3(-0.3f, 0.1f, 0);
                Instantiate(Cut2, tempPos2, transform.rotation);
                Cut2.GetComponent<DaikonRightDowble>().Vel = new Vector3(0.3f, 0.1f, 0);

                SoundManager.instance.SEPlay("おもちゃ切断SE");

                Destroy(gameObject);

                Debug.Log("左切");


            }
            else
            {
                other.GetComponent<Knife>().NotCut();
            }
            
        }
    }



}
