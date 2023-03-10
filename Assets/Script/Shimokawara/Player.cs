using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STICK_MOVE_TYPE
{
    ZAHYOU_KIJUN,
    KAMERA_KIJUN
}

public enum MOVE_INPUT_TYPE
{
    STICK_TYPE,
    KEY_TYPE
}


public class Player : MonoBehaviour
{


    public float MAX_SPEED = 9;

    static public Player instance;
    //カメラオブジェクト
    public GameObject cameraObj;

    public STICK_MOVE_TYPE StickMoveType;
    public MOVE_INPUT_TYPE MoveInputType;

    private Rigidbody Rb;

    public float moveX;
    public float moveZ;

    float moveY;

    public Vector2 LeftStick;
    Vector3 DefaultPos;


    static public float ADD_VEL_Y_DOWN = -0.5f;
    static public float MAX_VEL_Y_DOWN = -4.5f;

    static public float ADD_VEL_Y_UP = 0.35f;
    static public float MAX_VEL_Y_UP = 8.0f;

    public GameObject FrontMax;
    public GameObject BackMax;
    public GameObject RightMax;
    public GameObject LeftMax;

    float MIN_Z;
    float MAX_Z;
    float MIN_X;
    float MAX_X;

    //ジャンプキー
    //public KeyCode jumpKey = KeyCode.Space;


    void Start()
    {
        instance = this;

        //カメラオブジェクトを取得
        cameraObj = GameObject.Find("Main Camera");

        //Rigidbodyコンポーネントを取得
        Rb = this.GetComponent<Rigidbody>();
        moveY = 0;
        DefaultPos = Rb.transform.position;
        MIN_Z = FrontMax.transform.position.z;
        MAX_Z = BackMax.transform.position.z;
        MIN_X = LeftMax.transform.position.x;
        MAX_X = RightMax.transform.position.x;

    }

    void Update()
    {
        Rb.velocity = new Vector3(moveX, moveY, moveZ);

        PositionMaxMin();
    }

    void FixedUpdate() //FixedUpdateはUpdate(毎フレーム)と違って0.02秒毎に呼ばれる仕組みになっている※もちろん感覚は変更可
    {

        moveX *= 0.85f;
        moveZ *= 0.85f;

        ///////////////色関連（使ってない）
#if false
        //色を変更したときに、フェードで白に戻る
        float ColorR = this.GetComponent<Renderer>().material.color.r;
        ColorR = Mathf.Min(1.0f, ColorR + 0.05f);
        float ColorG = this.GetComponent<Renderer>().material.color.g;
        ColorG = Mathf.Min(1.0f, ColorG + 0.05f);
        float ColorB = this.GetComponent<Renderer>().material.color.b;
        ColorB = Mathf.Min(1.0f, ColorB + 0.05f);

        this.GetComponent<Renderer>().material.color = new Color(ColorR, ColorG, ColorB, 1.0f);
        //色終わり
#endif
        //スティック状態を初期化
        LeftStick = new Vector2(0, 0);


        //コントローラー取得
        switch (MoveInputType)
        {
            case MOVE_INPUT_TYPE.STICK_TYPE:
                LeftStick.x = Input.GetAxis("Horizontal");
                LeftStick.y = Input.GetAxis("Vertical");
                break;
            case MOVE_INPUT_TYPE.KEY_TYPE:
                LeftStick.x = Input.GetAxis("JuujiKeyX");
                LeftStick.y = Input.GetAxis("JuujiKeyY");
                break;
            default:
                break;
        }

      

        switch (StickMoveType)
        { 
        case STICK_MOVE_TYPE.ZAHYOU_KIJUN:
                ZahyouKijunMove();
                break;

        case STICK_MOVE_TYPE.KAMERA_KIJUN:
                CameraKijunMove();
                break;

        default:
                break;

        }

        TakasaMove();


    }



    void ZahyouKijunMove()
    {
        //ある程度左右入力があれば歩く
        if (LeftStick.x > 0.2f) // キー入力判定
        {
            // this.transform.localEulerAngles = new Vector3(0, -90, 0);
            moveX = Mathf.Max(MAX_SPEED * Mathf.Abs(LeftStick.x), moveX);
        }
        if (LeftStick.x < -0.2f) // キー入力判定
        {
            //this.transform.localEulerAngles = new Vector3(0, 90, 0);
            moveX = Mathf.Min(-MAX_SPEED * Mathf.Abs(LeftStick.x), moveX);
        }
        if (LeftStick.y > 0.2f) // キー入力判定
        {
            // this.transform.localEulerAngles = new Vector3(0, -90, 0);
            moveZ = Mathf.Max(MAX_SPEED * Mathf.Abs(LeftStick.y), moveZ);
        }
        if (LeftStick.y < -0.2f) // キー入力判定
        {
            //this.transform.localEulerAngles = new Vector3(0, 90, 0);
            moveZ = Mathf.Min(-MAX_SPEED * Mathf.Abs(LeftStick.y), moveZ);
        }
    }

    void CameraKijunMove()
    {
#if false
        //ある程度左右入力があれば歩く
        if (LeftStick.x > 0.2f) // キー入力判定
        {
            // this.transform.localEulerAngles = new Vector3(0, -90, 0);
            moveX = Mathf.Max(9, moveX);
        }
        if (LeftStick.x < -0.2f) // キー入力判定
        {
            //this.transform.localEulerAngles = new Vector3(0, 90, 0);
            moveX = Mathf.Min(-9, moveX);
        }
        if (LeftStick.y > 0.2f) // キー入力判定
        {
            // this.transform.localEulerAngles = new Vector3(0, -90, 0);
            moveZ = Mathf.Max(9, moveZ);
        }
        if (LeftStick.y < -0.2f) // キー入力判定
        {
            //this.transform.localEulerAngles = new Vector3(0, 90, 0);
            moveZ = Mathf.Min(-9, moveZ);
        }

        //⇑ここまで一緒
#endif
        //小さい入力を切り捨て
        if(Mathf.Abs(LeftStick.x) < 0.2f)
        {  LeftStick.x = 0;  }

        if (Mathf.Abs(LeftStick.y) < 0.2f)
        { LeftStick.y = 0; }

        float powerLength = Mathf.Sqrt(LeftStick.x * LeftStick.x + LeftStick.y * LeftStick.y);//強さ
        float powerAngle = Mathf.Atan2(LeftStick.y, LeftStick.x);//スティック倒す向き
        //カメラY周り分回す
        float cameraAngleR = cameraObj.transform.localEulerAngles.y * Mathf.PI / 180 /*- Mathf.PI * 0.5f*/;//カメラのまわり

        float moveAngle = powerAngle - cameraAngleR;//実際に動くアングルにするため加算

        float tempX = 0;
        float tempY = 0;

        tempX += (Mathf.Cos(moveAngle) * powerLength);
        //tempX += (Mathf.Sin(CameraAngleD) * moveZ);

        tempY += (Mathf.Sin(moveAngle) * powerLength);
        //tempZ += (Mathf.Cos(CameraAngleD) * moveZ);

        if(tempX > 0)
        {
            moveX = Mathf.Max(MAX_SPEED * Mathf.Abs(tempX), moveX);
        }
        if(tempX < 0)
        {
            moveX = Mathf.Min(-MAX_SPEED * Mathf.Abs(tempX), moveX);
        }
        if (tempY > 0)
        {
            moveZ = Mathf.Max(MAX_SPEED * Mathf.Abs(tempY), moveZ);
        }
        if (tempY < 0)
        {
            moveZ = Mathf.Min(-MAX_SPEED * Mathf.Abs(tempY), moveZ);
        }

    }

    void TakasaMove()
    {
        if (Input.GetButton("Rbutton"))
        {
            if (moveY > 0) moveY = 0;　//切り返し速く
            moveY = Mathf.Max(moveY + ADD_VEL_Y_DOWN, MAX_VEL_Y_DOWN);
        }
        else
        {
            if (moveY < 0) moveY = 0;　//切り返し速く
            moveY = Mathf.Min(moveY + ADD_VEL_Y_UP, MAX_VEL_Y_UP);
        }
    }

    void PositionMaxMin()
    {
        Vector3 tempPos = transform.position;
        if (transform.position.z > MAX_Z)
        {
            tempPos.z = MAX_Z;
        }
        if (transform.position.z < MIN_Z)
        {
            tempPos.z = MIN_Z;
        }
        if (transform.position.x > MAX_X)
        {
            tempPos.x = MAX_X;
        }
        if (transform.position.x < MIN_X)
        {
            tempPos.x = MIN_X;
        }
        if (Rb.position.y >= DefaultPos.y)
        {
            moveY = Mathf.Min(moveY, 0);

            tempPos.y = DefaultPos.y;
        }
        if (Rb.position.y < 9)
        {
            moveY = Mathf.Max(moveY, 0);

            tempPos.y = 9;
        }
        transform.position = tempPos;

       

        
    }
}

