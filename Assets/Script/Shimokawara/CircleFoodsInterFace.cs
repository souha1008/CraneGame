using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleFoodsInterFace : MonoBehaviour
{
    public enum FOODS_ARM_STATE
    {
        FREE,
        GLAB,
        //HIT_LEFT,
        //HIT_RIGHT
    }


    float GLAVITY = 0.006f;
    Vector3 Vel = Vector3.zero;

    public bool isGround = false;
    FOODS_ARM_STATE FoodsArmState;

    public GameObject LeftArm;
    public GameObject RightArm;

    float BallSize;
    RaycastHit LeftHit; //当たった結果を代入する変数
    RaycastHit RightHit; //当たった結果を代入する変数

    float leftDistance = 0;
    float rightDistance = 0;

    Color DefaultColor;
    Color GlabColor;

    Vector3 EscarateVector;

    // Start is called before the first frame update
    public void FoodsStart()
    {
        FoodsArmState = FOODS_ARM_STATE.FREE;
        isGround = false;
        BallSize = transform.localScale.x/* * transform.lossyScale.x*/;
        Debug.Log(transform.localScale.x);

        DefaultColor = this.GetComponent<Renderer>().material.color;
        GlabColor = this.GetComponent<Renderer>().material.color;
        GlabColor.b += 0.6f;

    }

    // Update is called once per frame
    public  void FoodsUpdate()
    {
        //Debug.Log(transform.localScale.x);
    }

    public  void FoodsFixedUpdate()
    {
        //キャラクターから真左方向へのレイを作成する
        Ray LeftRay = new Ray(this.transform.position, new Vector3(-1, 0, 0.0f).normalized);

        //キャラクターから真右方向へのレイを作成する
        Ray RightRay = new Ray(this.transform.position, new Vector3(1, 0, 0.0f).normalized);


        bool bLeftHit = false;
        bool bRightHit = false;


        if (Physics.Raycast(LeftRay, out LeftHit, 10.0f))
        {

            //あたったのが
            if (LeftHit.collider.gameObject == LeftArm)
            {

                leftDistance = LeftHit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                 //Debug.Log(distance);
                                                 //if (leftDistance < BallSize / 2 + 0.1f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                {
                    bLeftHit = true;
                    //Debug.Log("ひだり");
                }
            }
        }
        if (Physics.Raycast(RightRay, out RightHit, 10.0f))
        {

            //あたったのが
            if (RightHit.collider.gameObject == RightArm)
            {

                rightDistance = RightHit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                   //Debug.Log(distance);
                                                   // (rightDistance < BallSize / 2 + 0.1f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                {
                    bRightHit = true;
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
        //エスカレート処理
        if(isGround)
        {
            Vector3 tempPos = transform.position;
            tempPos += (EscarateVector * 0.05f);
            transform.position = tempPos;
        }
    }
    void GlabUpdate()
    {
        isGround = false;

        this.GetComponent<Renderer>().material.color = GlabColor;
        //Debug.Log("ぐらっぶ");

        Vector3 temp = (RightHit.point + LeftHit.point) / 2;
        temp.y = LeftArm.transform.position.y;
        temp.z = LeftArm.transform.position.z;

        this.transform.position = temp;

        if (Vector3.Distance(RightHit.point, LeftHit.point) < 0.5f * BallSize)
        {
            GetComponent<Renderer>().enabled = false;
        }

        //小さくする
        if (Vector3.Distance(RightHit.point, LeftHit.point) < BallSize)
        {
            Vector3 tempScale = transform.localScale;
            tempScale.x = BallSize * (Vector3.Distance(RightHit.point, LeftHit.point) / BallSize);

            transform.localScale = tempScale;
        }

        Vel = Vector3.zero;
    }

    void FreeUpdate()
    {
        Vector3 tempScale = new Vector3(BallSize,BallSize,BallSize);
        transform.localScale = tempScale;

        this.GetComponent<Renderer>().material.color = DefaultColor;

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
            if (underHit.collider.gameObject.tag == "EscarateUp"||
                underHit.collider.gameObject.tag == "EscarateRight"||
                underHit.collider.gameObject.tag == "EscarateDown")
            {
                float distance = underHit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                    //Debug.Log(distance);
                if (distance < BallSize / 2 + 0.1f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                {
                    isGround = true; //地面に接触している

                    if (Vel.y < 0.0f)
                        Vel.y = 0.0f;
                }

                if (underHit.collider.gameObject.tag == "EscarateUp")
                {
                    EscarateVector = new Vector3(0, 0, 1);
                }
                if (underHit.collider.gameObject.tag == "EscarateRight")
                {
                    EscarateVector = new Vector3(1, 0, 0);
                }
                if (underHit.collider.gameObject.tag == "EscarateDown")
                {
                    EscarateVector = new Vector3(0, 0, -1);
                }

            }
        }
    }
}