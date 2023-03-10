using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaine : MonoBehaviour
{
    static public Chaine instance;

    GameObject Ball;
    //振り子の時にフレーム数を数える
    int SwingCnt = 0;
    //長さ限度
    public float DISTANCE_MAX;
    float Distance;

    //振り子の振る速さ系    手探り
    float MAX_SWING_SPEED = 9;
    float ADD_SWING_SPEED = 0.94f;
    float FIRST_SWING_SPEED = 4;
    float SwingSpeed = 0;
   
    //振り子処女であるフラグ
    bool Shojo = true;

    //ボールが刺さった時のヒットストップカウント
    int HURIKO_FIRST_HIT_STOP = 3;

    //振り子やめた時に進む方向を逐一保存する
    public Vector3 WatasuVel = Vector3.zero;


    public void Start()
    {
        instance = this;

        //まだ振り子になってない
        Shojo = true;

        SwingCnt = 0;
        Distance = 0;

        if(GameObject.Find("Ball"))
        {
            Ball = GameObject.Find("Ball");
        }
        else
        {
            this.gameObject.SetActive(false);
        }

        SwingSpeed = 0;
        this.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {

        if (GameObject.Find("Ball"))
        {
            Ball = GameObject.Find("Ball");
        }
        //ボールがなければ消える
        else 
        {
            this.gameObject.SetActive(false);
            return;
        }



        switch (GameObject.Find("Ball").gameObject.GetComponent<Bullet>().BulletState)
        {
            case BULLET_STATE.GO:
                {
                    Vector3 TempPtoB = Ball.transform.position - Player.instance.transform.position;

                    float TempDistance = Vector3.Distance(TempPtoB, Vector3.zero);

                    //チェーンの長さ以上に離れようとしてる
                    if (TempDistance > DISTANCE_MAX)
                    {
                        //プレイヤーの場所変更

                        //場所無理矢理変更
                        Player.instance.transform.position = Ball.transform.position - (TempPtoB.normalized) * DISTANCE_MAX;

                        //カメラ更新
                        GameObject.Find("Main Camera").GetComponent<CameraPos>().ManualUpdate();

                    }


                    Vector3 PtoB = Ball.transform.position - Player.instance.transform.position;
                    //場所更新
                    transform.position = Vector3.Lerp(Player.instance.transform.position, Ball.transform.position, 0.5f);
                    //向き更新
                    float PtoB_Angle = Mathf.Atan2(PtoB.y, PtoB.x);
                    float ThisAngle_DO = PtoB_Angle / Mathf.PI * 180 + 90;
                    transform.localEulerAngles = new Vector3(0, 0, ThisAngle_DO);
                    //長さ更新
                    Distance = Vector3.Distance(PtoB, Vector3.zero);
                    transform.localScale = new Vector3(0.2f, Distance * 0.5f, 0.2f);

                }
                break;

            case BULLET_STATE.RETURN:
                {
                    Vector3 TempPtoB = Ball.transform.position - Player.instance.transform.position;
                    float TempDistance = Vector3.Distance(TempPtoB, Vector3.zero);

                    //長さを無理やり決める
                    //今の長さ と Distance - Speed の小さいほう
                    Distance = Mathf.Min(Distance - 0.5f, TempDistance);

                    //弾座標変更
                    Ball.transform.position = Player.instance.transform.position + TempPtoB.normalized * Distance;


                    Vector3 PtoB = Ball.transform.position - Player.instance.transform.position;
                    //場所更新
                    transform.position = Vector3.Lerp(Player.instance.transform.position, Ball.transform.position, 0.5f);
                    //向き更新
                    float PtoB_Angle = Mathf.Atan2(PtoB.y, PtoB.x);
                    float ThisAngle_DO = PtoB_Angle / Mathf.PI * 180 + 90;
                    transform.localEulerAngles = new Vector3(0, 0, ThisAngle_DO);
                    //長さ更新
                    Distance = Vector3.Distance(PtoB, Vector3.zero);
                    transform.localScale = new Vector3(0.2f, Distance * 0.5f, 0.2f);

                }
                break;


            case BULLET_STATE.STOP:
                {
                    SwingCnt++;
                    //反時計回りを １    時計回りを  -1   とする
                    int SpinHugou;
#if true
                    //真上や真下に刺さってる
                    if (Mathf.Abs(Bullet.instance.GetComponent<Rigidbody>().velocity.x) < 0.2f)
                    {
                        //プレイヤーの向きで回転決める
                        if (Player.instance.transform.localEulerAngles.y > 180)
                        {
                            SpinHugou = 1;
                            //Debug.Log("右回り");
                        }
                        else
                        {
                            SpinHugou = -1;
                            //Debug.Log("左回り");
                        }
                    }
                    //角度アリの刺さり方
                    else
                    {
                        //ボールが持ってる（持ってた）Vel準拠
                        if (Bullet.instance.GetComponent<Rigidbody>().velocity.x > 0)
                        {
                            SpinHugou = 1;
                        }
                        else
                        {
                            SpinHugou = -1;
                        }
                    }



#endif

                    Vector3 PtoB = Ball.transform.position - Player.instance.transform.position;

                    //ヒットストップ超えたら速度を持たせる
                    if (SwingCnt >= HURIKO_FIRST_HIT_STOP)
                    {
                        //初めての時だけ代入して初速を上げる
                        if (Shojo)
                        {
                            Shojo = false;
                            SwingSpeed = FIRST_SWING_SPEED;
                        }

                        SwingSpeed = Mathf.Min(SwingSpeed + ADD_SWING_SPEED, MAX_SWING_SPEED);
                    }

                    //今のアングル
                    Vector3 NowBtoP_Angle = (Player.instance.transform.position - Ball.transform.position).normalized;
                    //今のアングルを回す
                    Vector3 AfterBtoP_Angle = Quaternion.Euler(0, 0, SwingSpeed * SpinHugou) * NowBtoP_Angle;

                    //距離計算
                    //Distance = Vector3.Distance(PtoB, Vector3.zero);

                    //動かす前のプレイヤー座標保存
                    Vector3 SavePlayerPos = Player.instance.transform.position;

                    //プレイヤー場所変更
                    Player.instance.transform.position = Ball.transform.position + (AfterBtoP_Angle.normalized) * Distance;

                    //前Pos → いまPos のベクトルを保存  放り出されるときに使う
                    WatasuVel = Player.instance.transform.position - SavePlayerPos;

                    //場所更新
                    transform.position = Vector3.Lerp(Player.instance.transform.position, Ball.transform.position, 0.5f);
                    //向き更新
                    float PtoB_Angle = Mathf.Atan2(PtoB.y, PtoB.x);
                    float ThisAngle_DO = PtoB_Angle / Mathf.PI * 180 + 90;
                    transform.localEulerAngles = new Vector3(0, 0, ThisAngle_DO);
                    //長さ更新
                    transform.localScale = new Vector3(0.2f, Distance * 0.5f, 0.2f);


                    //反時計で、右のいい感じのとこに来たら放り投げ
                    if (SpinHugou == 1)
                    {
                        if (PtoB_Angle < Mathf.PI && PtoB_Angle > Mathf.PI - 0.5f)
                        {
                            WatasuVel.x *= 1.2f;
                           // Player.instance.ReturnDo();
                        }

                    }
                    //時計周りで、左のいい感じのとこに来たら放り投げ
                    else
                    {
                        //Debug.Log(PtoB_Angle);
                        if (PtoB_Angle > 0 && PtoB_Angle < 0.5f)
                        {
                            WatasuVel.x *= 1.2f;
                           
                        }

                    }
                }

                break;

            default:
                break;
        }


    }

    

}
