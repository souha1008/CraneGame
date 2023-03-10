using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BULLET_STATE
{
    GO,
    RETURN,
    STOP
}

public class Bullet : MonoBehaviour
{
    //マクロもどき
    static float MAX_SPEED = 90;
    static float ADD_SPEED = 30;

    static public Bullet instance;
    public BULLET_STATE BulletState;

    //振り子の時にボール固定される場所
    public Vector3 FreezePoint;
    private Rigidbody rb;
    //単位ベクトルの動く向き
    public Vector3 MoveDirection = Vector3.zero;
    
    float Speed = 0;

    int FCnt = 0;

    public void Start()
    {
        instance = this;

        FCnt = 0;

        BulletState = BULLET_STATE.GO;
        FreezePoint = Vector3.zero;
        
        //矢印が向いてる方向の取得
        if (GameObject.Find("UIYajirushi"))
        {
            MoveDirection = GameObject.Find("UIYajirushi").GetComponent<UIYajirushi>().Direction;
            //矢印は用済みだから消す
            UIYajirushi.instance.gameObject.SetActive(false);
        }

        Speed = MAX_SPEED;
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        //一旦これを非アクティブ （発射の時にPlayer.csで無理矢理trueにしてる）
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        FCnt++;

        switch (BulletState)
        {
            case BULLET_STATE.GO:
                
                //時間経過で引き戻し
                if(FCnt > 160)
                {
                    //Player.instance.ReturnDo(); 
                }

                if(FCnt > 10)
                {
                    float MoveX = MoveDirection.x * Speed;
                    float MoveY = MoveDirection.y * Speed - 2.6f;  //この3.6が重力   0なら無重力

                    //重力加算後のベクトル計算
                    Vector3 TempMove = new Vector3(MoveX, MoveY, 0);

                    //方向 向きを  ↑で計算したベクトルを使い更新
                    MoveDirection = TempMove.normalized;
                    Speed = Vector3.Distance(TempMove, Vector3.zero);
                }
                

                break;

            case BULLET_STATE.RETURN:

                //「プレイヤー → ボール」 の向きに対してスピードを乗算  (戻ってくるときのスピードはマイナス)

                //減速
                Speed = Mathf.Max(-MAX_SPEED, Speed - ADD_SPEED);

                //プレイヤー → ボールの向きを計算
                MoveDirection = (this.transform.position - 
                    GameObject.Find("Player").transform.position);
                //単位ベクトル化
                MoveDirection = MoveDirection.normalized;
                break;

            case BULLET_STATE.STOP:
                //止まる場所に座標移動
                this.transform.position = FreezePoint;

                break;

            default:
                break;
        }

        rb.velocity = MoveDirection * Speed;

    }

 

    void OnTriggerEnter(Collider collisionInfo)
    {

        //進行中に床に当たれば、振り子状態になるだけ

        if (collisionInfo.gameObject.tag == "PlatForm")
        {
            if (BulletState == BULLET_STATE.GO)
            {
                if (collisionInfo.GetComponent<Cube>().CubeType == CUBE_TYPE.MOVE ||
                    collisionInfo.GetComponent<Cube>().CubeType == CUBE_TYPE.CONVEYOR)
                {
                    collisionInfo.GetComponent<Cube>().GlabCube = true;

                }

                    Vector3 hitPos = Vector3.zero;

                    hitPos = collisionInfo.ClosestPointOnBounds(this.transform.position);
                    FreezePoint = hitPos;

                    this.transform.position = hitPos;

                    BulletState = BULLET_STATE.STOP;
                
            }
        }
    }

    void OnTriggerStay(Collider collisionInfo)
    {
        //リターン中にプレイヤーに当たればなくなるだけ

        if (collisionInfo.gameObject.tag == "Player")
        {
            if(BulletState == BULLET_STATE.RETURN)
            {

                collisionInfo.gameObject.SendMessage("ReturnBall");
                collisionInfo.gameObject.GetComponent<Rigidbody>().useGravity = true;

                this.gameObject.SetActive(false);

            }
        }
    }
}