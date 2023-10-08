using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Stake : CircleFoodsInterFace
{
    public int FireCnt = 0;
    bool FireFlag;

    public bool isFire = false;
    public int Number;
    static int StaticNumber = 0;
    public GameObject Effect;
    void Start()
    {
        FoodsStart();
        Number = StaticNumber;
        StaticNumber++;

    }
    private void OnEnable()
    {
        Effect.SetActive(false);
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
                        GetComponent<stake_ColorTransfer>().ZeroToOne(0.02f);
                    }
                }
                
            }
        }
        FireFlag = false;

        if (isFire)
        {
            Effect.SetActive(true);
        }

        FoodsFixedUpdate();
    }

    public override void Cut(Collider other)
    {



        if (!isNoAction/* && isGround*/)
        {
            float SizeX = transform.localScale.x;

            float X_Vector = (other.transform.position.x - transform.position.x);

            if (X_Vector > SizeX / 12 && X_Vector < SizeX / 12 * 4)
            {
                GameObject Cut1 = (GameObject)Resources.Load("StakeLeftDowble");
                GameObject Cut2 = (GameObject)Resources.Load("StakeRightSingle");

                Vector3 tempPos1 = transform.position;
                Vector3 tempPos2 = transform.position;
                tempPos1.x -= 3;
                tempPos2.x += 3;//右
                                // Cubeプレハブを元に、インスタンスを生成、
                Cut1 = Instantiate(Cut1, tempPos1, transform.rotation);
                Cut1.GetComponent<StakeLeftDowble>().Vel = new Vector3(-0.3f, 0.1f, 0);
                Cut1.GetComponent<StakeLeftDowble>().isFire = isFire;
                if(Cut1.GetComponent<StakeLeftDowble>().isFire)
                    Cut1.GetComponent<stake_ColorTransfer>().SetParm(1);
                Cut1.GetComponent<StakeLeftDowble>().Number = Number;
                Cut2 = Instantiate(Cut2, tempPos2, transform.rotation);
                Cut2.GetComponent<StakeRightSingle>().Vel = new Vector3(0.3f, 0.1f, 0);
                Cut2.GetComponent<StakeRightSingle>().isFire = isFire;
                if (Cut2.GetComponent<StakeRightSingle>().isFire)
                {
                    Cut2.GetComponent<stake_ColorTransfer>().SetParm(1);
                    Debug.Log("セットパラム呼び出し");
                }
                    
                Cut2.GetComponent<StakeRightSingle>().Number = Number;

                SoundManager.instance.SEPlay("おもちゃ切断SE");

                Destroy(gameObject);
            }

            else if (X_Vector < -SizeX / 12 && X_Vector > -SizeX / 12 * 4)
            {

                GameObject Cut1 = (GameObject)Resources.Load("StakeLeftSingle");
                GameObject Cut2 = (GameObject)Resources.Load("StakeRightDowble");

                Vector3 tempPos1 = transform.position;
                Vector3 tempPos2 = transform.position;
                tempPos1.x -= 3;
                tempPos2.x += 3;//右
                                // Cubeプレハブを元に、インスタンスを生成、
                Cut1 = Instantiate(Cut1, tempPos1, transform.rotation);
                Cut1.GetComponent<StakeLeftSingle>().Vel = new Vector3(-0.3f, 0.1f, 0);
                Cut1.GetComponent<StakeLeftSingle>().isFire = isFire;
                if (Cut1.GetComponent<StakeLeftSingle>().isFire)
                    Cut1.GetComponent<stake_ColorTransfer>().SetParm(1);
                Cut1.GetComponent<StakeLeftSingle>().Number = Number;
                Cut2 = Instantiate(Cut2, tempPos2, transform.rotation);
                Cut2.GetComponent<StakeRightDowble>().Vel = new Vector3(0.3f, 0.1f, 0);
                Cut2.GetComponent<StakeRightDowble>().isFire = isFire;
                if (Cut2.GetComponent<StakeRightDowble>().isFire)
                    Cut2.GetComponent<stake_ColorTransfer>().SetParm(1);
                Cut2.GetComponent<StakeRightDowble>().Number = Number;

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
