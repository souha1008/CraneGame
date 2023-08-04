using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    // Start is called before the first frame update

    float UnLockAngle;

    public enum LEFT_OR_RIGHT
    {
        Left,
        Right
    }

    public float rAngle;
    float oldAngle;
    public float MIN_ANGLE = 0;
    public float MAX_ANGLE = Mathf.PI * 0.5f;
    float rAngleSpeed = 0;
    float MAX_ANGLE_SPEED = Mathf.PI * 0.5f / 15;
    float ADD_ANGLE_SPEED = (Mathf.PI * 0.5f / 15) / 4;

    public LEFT_OR_RIGHT LeftOrRight;
    int Direction = 1;

    public GameObject LockTex;
    public bool isUnLock = false;

    public bool HitFood;

    public GameObject playerObj;
    Vector3 PosVector;

    bool LTrigger = false;

    public void custumStart(int direction)
    {
        isUnLock = false;

        PosVector = transform.position - playerObj.transform.position;

        if(LeftOrRight == LEFT_OR_RIGHT.Left)
        {
            Direction = direction;
        }
        else
        {
            Direction = direction;
        }
    }

    // Update is called once per frame
    public void custumUpdate()
    {
        SneekPlayer();

        Quaternion rot = Quaternion.AngleAxis(Direction * rAngle * 180 / Mathf.PI, Vector3.forward);

        this.transform.rotation = rot;

        if(Input.GetButtonDown("Lbutton"))
        {
            LTrigger = true;
        }
    }

    void SneekPlayer()
    {
        transform.position = playerObj.transform.position + PosVector;
    }

    public void custumFixedUpdate(ArmManager.ARM_STICK_TYPE armStickType , ARM_MOVE armMove , int Size)
    {
        switch (armStickType)
        {
            case ArmManager.ARM_STICK_TYPE.OOKUMA_KIMOI:
                OokumaKimoi();
                break;
            case ArmManager.ARM_STICK_TYPE.AKIYAMA_HANGETSU:
                AkiyamaHangetsu(armMove , Size);
                break;
            case ArmManager.ARM_STICK_TYPE.BUTTON_PUSH:
                ButtonPush();
                break;
            case ArmManager.ARM_STICK_TYPE.RIGHT_STICK_UPDOWN:
                RightStickUpDown();
                break;
            case ArmManager.ARM_STICK_TYPE.RIGHT_STICK_CENTER_DOWN:
                RightStickCenterDown();
                break;
            default:
                break;
        }





        LTrigger = false;


    }

   void OokumaKimoi()
    {

        float temp;
        if(Direction == 1)//ひだり
        {
            temp = Mathf.Max(Input.GetAxis("Horizontal"), 0);
        }
        else//みぎ
        {
            temp = Mathf.Min(Input.GetAxis("RightX"), 0) * -1;
        }

        rAngle = temp * MAX_ANGLE;
    }
    void AkiyamaHangetsu(ARM_MOVE armMove , int Size)
    {
        oldAngle = rAngle;

        Vector2 LeftStick;
        LeftStick.x = Input.GetAxis("RightX");
        LeftStick.y = Input.GetAxis("RightY");

        float length = Mathf.Sqrt(LeftStick.x * LeftStick.x + LeftStick.y * LeftStick.y);//大きさ

        if(length <= 0.7f)//小さすぎてカット
        {
            isUnLock = false;
        }
        //下じゃなきゃ開かない
        //if (length > 0.85f && 
        //    (Mathf.Atan2(LeftStick.y , LeftStick.x) <= (-Mathf.PI / 2 + 0.2f)) &&
        //    (Mathf.Atan2(LeftStick.y , LeftStick.x) >= (-Mathf.PI / 2 - 0.2f)))
        if (length > 0.85f && !isUnLock /*&&
    (Mathf.Atan2(LeftStick.y, LeftStick.x) <= (-Mathf.PI / 2 + 0.2f)) &&
    (Mathf.Atan2(LeftStick.y, LeftStick.x) >= (-Mathf.PI / 2 - 0.2f))*/ 
    //&&
    //Input.GetButton("Lbutton")
    )
        {
            isUnLock = true;
            UnLockAngle = Mathf.Atan2(LeftStick.y, LeftStick.x);
        }

        //上にいる
        //if(!Input.GetButton("Lbutton"))
        //{
        //    isUnLock = false;
        //}

        if(LTrigger)
        {
            isUnLock = false;
        }

        //締め処理
        if(isUnLock)
        {
            //tempは0～1
            //float temp = ((Input.GetAxis("RightY")) + 1) * 0.5f;

            float Angle_Sa = /*Mathf.Abs*/(UnLockAngle - Mathf.Atan2(LeftStick.y, LeftStick.x));
            Angle_Sa = Angle_Sa_naoshi(Angle_Sa);
            //Debug.Log(Angle_Sa);
            float temp = Angle_Sa / Mathf.PI;
            float goAngle = temp * MAX_ANGLE;

            switch (armMove)
            {
                case ARM_MOVE.MOVE:
                    rAngle = goAngle;
                    break;

                case ARM_MOVE.SLOW:
                    if (goAngle >= oldAngle)
                    {
                        rAngle = (goAngle - oldAngle) * 0.04f + oldAngle;
                    }
                    else
                    {
                        rAngle = goAngle;
                    }
                    
                    break;

                case ARM_MOVE.STOP:

                    

                    //スイッチで大きさによって変える

                    //switch (Size)
                    //{
                    //    case 5:
                    //        if(goAngle >= 1.15f)
                    //        {
                    //            goAngle = 1.15f;
                    //        }
                          
                    //        break;


                    //}

                    //これがもともと
                    rAngle = Mathf.Min(goAngle, oldAngle);
                    break;

            }


            if (LockTex)
            {
                LockTex.GetComponent<Renderer>().enabled = false;
            }
        }

        else
        {
            rAngle = 0;
            if (LockTex)
            {
                LockTex.GetComponent<Renderer>().enabled = true;
            }
        }
    }
    void ButtonPush()
    {
        if (Input.GetButton("Jump"))
        //if (Input.GetButton("Lbutton"))
        //if (true)
        {
            if (rAngleSpeed < 0) rAngleSpeed = 0;//切り返し速く
            rAngleSpeed = Mathf.Min(rAngleSpeed + ADD_ANGLE_SPEED, MAX_ANGLE_SPEED);


            rAngle += rAngleSpeed;
            if (rAngle >= MAX_ANGLE)
            {
                rAngle = MAX_ANGLE;
                rAngleSpeed = 0;
            }
        }
        else
        {
            if (rAngleSpeed > 0) rAngleSpeed = 0;//切り返し速く
            rAngleSpeed = Mathf.Max(rAngleSpeed - ADD_ANGLE_SPEED, -MAX_ANGLE_SPEED);


            rAngle += rAngleSpeed;
            if (rAngle <= MIN_ANGLE)
            {
                rAngle = MIN_ANGLE;
                rAngleSpeed = 0;
            }
        }
    }
    void RightStickUpDown()
    {
        float temp = ((Input.GetAxis("RightY")) + 1) * 0.5f;
        rAngle = temp * MAX_ANGLE;

    }
    void RightStickCenterDown()
    {
        float temp = Mathf.Max((Input.GetAxis("RightY")) , 0.0f);
        rAngle = temp * MAX_ANGLE;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CircleFoodsInterFace>())
        {
            HitFood = true;
        }
    }

    private float Angle_Sa_naoshi(float Angle_Sa )
    {
        if(Angle_Sa < 0)
        {
            Angle_Sa += (Mathf.PI * 2);
        }
        if (Angle_Sa > Mathf.PI * 2)
        {
            Angle_Sa -= (Mathf.PI * 2);
        }

        if(Angle_Sa > Mathf.PI)
        {
            Angle_Sa = Mathf.PI * 2 - Angle_Sa;
        }

        return Angle_Sa;


    }
}
