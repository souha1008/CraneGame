using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    // Start is called before the first frame update

   

    public enum LEFT_OR_RIGHT
    {
        Left,
        Right
    }

    float rAngle;
    float oldAngle;
    float MIN_ANGLE = 0;
    float MAX_ANGLE = Mathf.PI * 0.5f;
    float rAngleSpeed = 0;
    float MAX_ANGLE_SPEED = Mathf.PI * 0.5f / 15;
    float ADD_ANGLE_SPEED = (Mathf.PI * 0.5f / 15) / 4;

    public LEFT_OR_RIGHT LeftOrRight;
    int Direction = 1;

    public GameObject LockTex;
    bool isUnLock = false;

    public bool HitFood;

    public GameObject playerObj;
    Vector3 PosVector;

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
    }

    void SneekPlayer()
    {
        transform.position = playerObj.transform.position + PosVector;
    }

    public void custumFixedUpdate(ArmManager.ARM_STICK_TYPE armStickType , ARM_MOVE armMove)
    {
        switch (armStickType)
        {
            case ArmManager.ARM_STICK_TYPE.OOKUMA_KIMOI:
                OokumaKimoi();
                break;
            case ArmManager.ARM_STICK_TYPE.AKIYAMA_HANGETSU:
                AkiyamaHangetsu(armMove);
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






       
    }

   void OokumaKimoi()
    {

        float temp;
        if(Direction == 1)//Ç–ÇæÇË
        {
            temp = Mathf.Max(Input.GetAxis("Horizontal"), 0);
        }
        else//Ç›Ç¨
        {
            temp = Mathf.Min(Input.GetAxis("RightX"), 0) * -1;
        }

        rAngle = temp * MAX_ANGLE;
    }
    void AkiyamaHangetsu(ARM_MOVE armMove)
    {
        oldAngle = rAngle;

        Vector2 LeftStick;
        LeftStick.x = Input.GetAxis("RightX");
        LeftStick.y = Input.GetAxis("RightY");

        float length = Mathf.Sqrt(LeftStick.x * LeftStick.x + LeftStick.y * LeftStick.y);//ëÂÇ´Ç≥

        if(length <= 0.7f)//è¨Ç≥Ç∑Ç¨ÇƒÉJÉbÉg
        {
            isUnLock = false;
        }
        
        if (length > 0.85f && 
            (Mathf.Atan2(LeftStick.y , LeftStick.x) <= (-Mathf.PI / 2 + 0.2f)) &&
            (Mathf.Atan2(LeftStick.y , LeftStick.x) >= (-Mathf.PI / 2 - 0.2f)))
        {
            isUnLock = true;
        }
        //í˜Çﬂèàóù
        if(isUnLock)
        {
            float temp = ((Input.GetAxis("RightY")) + 1) * 0.5f;
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

                    //float TeikouAngle = 
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
            if (rAngleSpeed < 0) rAngleSpeed = 0;//êÿÇËï‘Çµë¨Ç≠
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
            if (rAngleSpeed > 0) rAngleSpeed = 0;//êÿÇËï‘Çµë¨Ç≠
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
}
