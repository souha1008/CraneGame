using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class StakeLeftDowble : CircleFoodsInterFace
{
    public int FireCnt = 0;
    bool FireFlag;

    public bool isFire = false;
    public int Number;

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
        if (!isFire)
        {
            if (!isNoAction)
            {
                if (FireFlag)
                {
                    FireCnt++;

                    if (FireCnt > 10)
                    {
                        isFire = true;
                    }
                }

            }
        }
        FireFlag = false;
        FoodsFixedUpdate();
    }

    public override void Cut(Collider other)
    {
        if (!isNoAction /*&& isGround*/)
        {
            float SizeX = transform.localScale.x;

            float Distance = Mathf.Abs(transform.position.x - other.transform.position.x);

            if (Distance < SizeX * 0.25f)
            {
                GameObject Cut1 = (GameObject)Resources.Load("StakeCenterSingle");
                GameObject Cut2 = (GameObject)Resources.Load("StakeLeftSingle");

                Vector3 tempPos1 = transform.position;
                Vector3 tempPos2 = transform.position;
                tempPos1.x += 3;//右
                tempPos2.x -= 3;
                // Cubeプレハブを元に、インスタンスを生成、

                Cut1 = Instantiate(Cut1, tempPos1, transform.rotation);
                Cut1.GetComponent<StakeCenterSingle>().Vel = new Vector3(0.3f, 0.1f, 0);
                Cut1.GetComponent<StakeCenterSingle>().isFire = isFire;
                Cut1.GetComponent<StakeCenterSingle>().Number = Number;
                Cut2 = Instantiate(Cut2, tempPos2, transform.rotation);
                Cut2.GetComponent<StakeLeftSingle>().Vel = new Vector3(-0.3f, 0.1f, 0);
                Cut2.GetComponent<StakeLeftSingle>().isFire = isFire;
                Cut2.GetComponent<StakeLeftSingle>().Number = Number;
                SoundManager.instance.SEPlay("おもちゃ切断SE");

                Destroy(gameObject);
            }
            else
            {
                other.GetComponent<Knife>().NotCut();
            }

        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
        {
            if (other.GetComponent<Fire>().FireState == FIRE_STATE.FIRE_FIRE)
            {
                FireFlag = true;
            }
        }

    }
}