using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//つかみのスケールどうする
//

public enum ChachAction
{
    HARD,
    SOFT,
    CANNOT
}

public enum CutAction
{
    CAN,
    CANNOT
}

public enum HummerAction
{
    ACTION,
    STAY,
    SCALE
}

public enum FireAction
{
    ACTION,
    STAY,
    KOGE
}




public class CircleFoodsInterFace : MonoBehaviour
{
    public enum FOODS_ARM_STATE
    {
        FREE,
        GLAB,
        //HIT_LEFT,
        //HIT_RIGHT
    }


    //料理フラグ
    public ChachAction m_ChachAction;
    public CutAction m_CutAction;
    public HummerAction m_HummerAction;
    public FireAction m_FireAction;

    public bool isNoAction = false;

    public bool isClear = false;

    Vector3 LeftArmPosition;
    Vector3 RightArmPosition;

    float GLAVITY = 0.006f;
    public Vector3 Vel = Vector3.zero;

    public bool isGround = false;
    public FOODS_ARM_STATE FoodsArmState;

    float BallSize;
    RaycastHit LeftHit; //当たった結果を代入する変数
    RaycastHit RightHit; //当たった結果を代入する変数

    float leftDistance = 0;
    float rightDistance = 0;


    // Start is called before the first frame update
    public void FoodsStart()
    {
        FoodsArmState = FOODS_ARM_STATE.FREE;
        isGround = false;
        BallSize = transform.localScale.x/* * transform.lossyScale.x*/;
        //Debug.Log(transform.localScale.x);


        //LeftArm = GameObject.Find("ArmBord1");
        //RightArm = GameObject.Find("ArmBord2");
    }

    // Update is called once per frame
    public void FoodsUpdate()
    {
        if (isClear)
        {
            //黒
            //gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
        else
        {
            //白
            //gameObject.GetComponent<Renderer>().material.color = Color.white;

        }

        if (FoodsArmState == FOODS_ARM_STATE.GLAB)
        {
            Vector3 temp = (RightHit.point + LeftHit.point) / 2;
            temp.y = LeftArmPosition.y;
            temp.z = LeftArmPosition.z;

            this.transform.position = temp;
        }

        //Debug.Log(transform.localScale.x);
    }

    public void FoodsFixedUpdate()
    {
        Vel.x *= 0.95f;
        Vel.z *= 0.95f;

        if (m_ChachAction != ChachAction.CANNOT)
        {

            //キャラクターから真左方向へのレイを作成する
            Ray LeftRay = new Ray(this.transform.position, new Vector3(-1, 0, 0.0f).normalized);

            //キャラクターから真右方向へのレイを作成する
            Ray RightRay = new Ray(this.transform.position, new Vector3(1, 0, 0.0f).normalized);


            bool bLeftHit = false;
            bool bRightHit = false;


            if (Physics.Raycast(LeftRay, out LeftHit, 10.0f))
            {
                //Debug.Log(LeftArm);
                //あたったのが
                if (LeftHit.collider.gameObject.tag == "LeftArm")
                {
                    leftDistance = LeftHit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                     //Debug.Log(distance);
                                                     //if (leftDistance < BallSize / 2 + 0.1f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                    {
                        bLeftHit = true;
                        LeftArmPosition = LeftHit.collider.transform.position;

                        //Debug.Log("ひだり");
                    }
                }
            }
            if (Physics.Raycast(RightRay, out RightHit, 10.0f))
            {

                //あたったのが
                if (RightHit.collider.gameObject.tag == "RightArm")
                {

                    rightDistance = RightHit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                       //Debug.Log(distance);
                                                       // (rightDistance < BallSize / 2 + 0.1f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                    {
                        bRightHit = true;
                        RightArmPosition = RightHit.collider.transform.position;
                        //Debug.Log("みぎ");
                    }
                }
            }

            if (bLeftHit && bRightHit && (Vector3.Distance(RightHit.point, LeftHit.point) <= BallSize))
            {
                FoodsArmState = FOODS_ARM_STATE.GLAB;
                // Debug.Log("GLAB");
            }
            //else if(bLeftHit)
            //{
            //    MikanState = MIKAN_STATE.HIT_LEFT;
            //}
            //else if(bRightHit)
            //{
            //    MikanState = MIKAN_STATE.HIT_RIGHT;
            //}
            else
            {
                FoodsArmState = FOODS_ARM_STATE.FREE;
            }
        }

        switch (FoodsArmState)
        {
            case FOODS_ARM_STATE.GLAB:
                GlabUpdate();
                break;

            case FOODS_ARM_STATE.FREE:
                FreeUpdate();
                break;

            default:
                break;
        }
       

    }
    void GlabUpdate()
    {
        isGround = false;

        

        Vector3 temp = (RightHit.point + LeftHit.point) / 2;
        temp.y = LeftArmPosition.y;
        temp.z = LeftArmPosition.z;

        this.transform.position = temp;

        if (m_ChachAction == ChachAction.SOFT)
        {
            if (Vector3.Distance(RightHit.point, LeftHit.point) < 0.2f * BallSize)
            {
                Destroy(gameObject);
                //GetComponent<Renderer>().enabled = false;
            }

            //小さくする
            if (Vector3.Distance(RightHit.point, LeftHit.point) < BallSize)
            {
                Vector3 tempScale = transform.localScale;
                tempScale.x = BallSize * (Vector3.Distance(RightHit.point, LeftHit.point) / BallSize);

                transform.localScale = tempScale;
            }
        }



        Vel = Vector3.zero;
    }

    void FreeUpdate()
    {
        if(isNoAction == false)
        {
            Vector3 tempScale = new Vector3(BallSize, BallSize, BallSize);
            transform.localScale = tempScale;
        }
    

        transform.position += Vel;

        Vel.y -= GLAVITY;

        isGround = false; //地面に接触している


        //キャラクターから真下方向へのレイを作成する
        Ray underRay = new Ray(this.transform.position, new Vector3(0.0f, -1.0f, 0.0f).normalized);
        RaycastHit underHit; //当たった結果を代入する変数
        //レイを飛ばしてオブジェクトに当たれば
        if (Physics.Raycast(underRay, out underHit, 10.0f))
        {
            //あたったのがプラットフォームなら
            if (underHit.collider.gameObject.tag == "EscarateUp" ||
                underHit.collider.gameObject.tag == "EscarateRight" ||
                underHit.collider.gameObject.tag == "EscarateDown" ||
                underHit.collider.gameObject.tag == "EscarateNone")
            {
                float distance = underHit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                    //Debug.Log(distance);
                if (distance < (BallSize / 2) * 1.2f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                {
                    isGround = true; //地面に接触している

                    if (Vel.y < 0.0f)
                        Vel.y = 0.0f;
                }

               
            }
        }
    }

    public virtual void Fire(Collider other)
    {
        //Debug.Log("炎");
    }
    public virtual void Hummer(Collider other)
    {
        //Debug.Log("ハンマー");

    }

    public virtual void Cut(Collider other)
    {
        //Debug.Log("ｶｯﾄ");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttachHummer")
        {
            Hummer(other);
            if (m_HummerAction == HummerAction.SCALE)
            {
                Vector3 temp = transform.localScale;
                //Debug.Log("transform.localScale");
                float Moving = temp.y * 0.40f;

                transform.position = new Vector3(transform.position.x, transform.position.y - Moving, transform.position.z);
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.1f, transform.localScale.z);

                //変更
                //移動も回転もしないようにする
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                m_HummerAction = HummerAction.STAY;
                m_CutAction = CutAction.CANNOT;
                m_FireAction = FireAction.STAY;
                m_ChachAction = ChachAction.CANNOT;

                isNoAction = true;

                //Debug.Log("ハンマー2");
            }
        }

        else if (other.gameObject.tag == "AttachKnife")
        {
            Cut(other);
            if (m_CutAction == CutAction.CANNOT)
            {
                //if(!gameObject.GetComponent<CutDaikon>())
                {
                    other.gameObject.GetComponent<Knife>().NotCut();
                }

            }

        }
        else if (other.gameObject.tag == "AttachFire")
        {
            Fire(other);
        }
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.gameObject == LeftArm || other.gameObject == RightArm)
    //    {
    //        Debug.Log("Hit");

    //        Vector3 PosVector = other.transform.position - transform.position;

    //        if(LeftArm.transform.localScale.z / 2 > Mathf.Abs( PosVector.z))
    //        {
    //            if(PosVector.z > 0)//アームが奥
    //            {
    //                Vector3 TempPos = transform.position;
    //                TempPos.z = other.gameObject.transform.position.z - LeftArm.transform.localScale.z;
    //                transform.position = TempPos;
    //            }
    //            else
    //            {
    //                Vector3 TempPos = transform.position;
    //                TempPos.z = other.gameObject.transform.position.z +LeftArm.transform.localScale.z;
    //                transform.position = TempPos;
    //            }
    //        }

    //    }

    //}
}