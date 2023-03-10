using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CUBE_TYPE
{
    NOMAL,
    MOVE,
    CONVEYOR
}

public class Cube : MonoBehaviour
{
    public CUBE_TYPE CubeType = CUBE_TYPE.NOMAL;

    int Cnt = 0;
    float MoveX = 0;
    float MAX_MOVE = 30.0f;
    float ADD_MOVE = 30.0f / 10;

    float SPIN_CONVEYOR = 1.5f;

    //カーソルくっついているか？フラグ
    public bool GlabCube = false;


    Vector3 OldPos = Vector3.zero;
    Vector3 Pos = Vector3.zero;
    //OldPosからPosへ動いた両保存
    Vector3 MoveLength = Vector3.zero;

    void Start()
    {
        Cnt = 0;
        GlabCube = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bullet.instance)
        {
            if (Bullet.instance.BulletState == BULLET_STATE.RETURN)
            {
                GlabCube = false;
            }
        }


        if (CubeType == CUBE_TYPE.MOVE)

        {
            this.transform.GetComponent<Rigidbody>().velocity = new Vector3(MoveX, 0, 0);

            OldPos = Pos;
            Pos = this.transform.position;

            MoveLength = Pos - OldPos;

            RaycastHit[] hits; //当たった結果を代入する変数

            /////////////////////////////// ここからプレイヤー乗ってるか？判定
            //配列に格納
            hits = Physics.BoxCastAll(transform.position,
                GetComponent<Collider>().bounds.size * 0.5f,
                new Vector3(0.0f, 1.0f, 0.0f).normalized);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("当たってる");

                    float distance = hit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                   //Debug.Log(distance);
                    if (distance < this.GetComponent<Collider>().bounds.size.y / 2 + 1.2f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                    {
                        Debug.Log("乗ってる");
                        Player.instance.transform.position += MoveLength;
                    }
                    break;
                }
            }

            ////////////////////プレイヤー乗ってるか？判定おわり
            ///

            if(GlabCube)
            {
                Bullet.instance.FreezePoint += MoveLength;
            }

        }
    }

    void FixedUpdate()
    {

        //動く計算
        if (CubeType == CUBE_TYPE.MOVE)
        {

            Cnt++;

            if ((Cnt / 120) % 2 == 0)
            {
                MoveX = Mathf.Min(MoveX + ADD_MOVE, MAX_MOVE);
            }
            else
            {
                MoveX = Mathf.Max(MoveX - ADD_MOVE, -MAX_MOVE);

            }
        }



        if (CubeType == CUBE_TYPE.CONVEYOR)

        {
            this.transform.GetComponent<Rigidbody>().velocity = new Vector3(MoveX, 0, 0);

            RaycastHit[] hits; //当たった結果を代入する変数

            /////////////////////////////// ここからプレイヤー乗ってるか？判定
            //配列に格納
            hits = Physics.BoxCastAll(transform.position,
                GetComponent<Collider>().bounds.size * 0.5f,
                new Vector3(0.0f, 1.0f, 0.0f).normalized);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("当たってる");

                    float distance = hit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                   //Debug.Log(distance);
                    if (distance < this.GetComponent<Collider>().bounds.size.y / 2 + 1.2f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                    {
                        Debug.Log("乗ってる");
                        Player.instance.transform.position += new Vector3(SPIN_CONVEYOR,0,0);
                    }
                    break;
                }
            }

            ////////////////////プレイヤー乗ってるか？判定おわり
            ///

            if (GlabCube)
            {
                RaycastHit[] hits2; //当たった結果を代入する変数

                /////////////////////////////// ここからプレイヤー乗ってるか？判定
                //配列に格納
                hits2 = Physics.BoxCastAll(transform.position,
                    GetComponent<Collider>().bounds.size * 0.5f,
                    new Vector3(0.0f, 1.0f, 0.0f).normalized);

                for (int i = 0; i < hits2.Length; i++)
                {
                    RaycastHit hit = hits2[i];
                    if (hit.collider.gameObject.tag == "Ball")
                    {


                        float distance = hit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                       //Debug.Log(distance);
                        if (distance < this.GetComponent<Collider>().bounds.size.y / 2 + 1.2f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                        {
                            if (Bullet.instance.GetComponent<Rigidbody>().velocity.y < 0)
                            {
                                Bullet.instance.FreezePoint += new Vector3(SPIN_CONVEYOR, 0, 0);
                            }
                            else
                            {
                                Bullet.instance.FreezePoint += new Vector3(-SPIN_CONVEYOR, 0, 0);

                            }
                        }
                        break;
                    }
                }

                ////////////////////プレイヤー乗ってるか？判定おわり







                RaycastHit[] hits3; //当たった結果を代入する変数

                /////////////////////////////// ここからプレイヤー乗ってるか？判定
                //配列に格納
                hits3 = Physics.BoxCastAll(transform.position,
                    GetComponent<Collider>().bounds.size * 0.5f,
                    new Vector3(0.0f, -1.0f, 0.0f).normalized);

                for (int i = 0; i < hits3.Length; i++)
                {
                    RaycastHit hit = hits3[i];
                    if (hit.collider.gameObject.tag == "Ball")
                    {


                        float distance = hit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                       //Debug.Log(distance);
                        if (distance < this.GetComponent<Collider>().bounds.size.y / 2 + 1.2f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                        {
                            if (Bullet.instance.GetComponent<Rigidbody>().velocity.y < 0)
                            {
                                Bullet.instance.FreezePoint += new Vector3(SPIN_CONVEYOR, 0, 0);
                            }
                            else
                            {
                                Bullet.instance.FreezePoint += new Vector3(-SPIN_CONVEYOR, 0, 0);

                            }
                        }
                        break;
                    }
                }

                ////////////////////プレイヤー乗ってるか？判定おわり
            }

        }

    }
}
