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
    float MIN_ANGLE = 0;
    float MAX_ANGLE = Mathf.PI * 0.5f;
    float rAngleSpeed = 0;
    float MAX_ANGLE_SPEED = Mathf.PI * 0.5f / 15;
    float ADD_ANGLE_SPEED = (Mathf.PI * 0.5f / 15) / 4;

    public LEFT_OR_RIGHT LeftOrRight;
    int Direction = 1;

    public GameObject LockTex;
    bool isUnLock = false;


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

    public void custumFixedUpdate(ArmManager.ARM_STICK_TYPE armStickType)
    {
        switch (armStickType)
        {
            case ArmManager.ARM_STICK_TYPE.OOKUMA_KIMOI:
                OokumaKimoi();
                break;
            case ArmManager.ARM_STICK_TYPE.AKIYAMA_HANGETSU:
                AkiyamaHangetsu();
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
        if(Direction == 1)//�Ђ���
        {
            temp = Mathf.Max(Input.GetAxis("Horizontal"), 0);
        }
        else//�݂�
        {
            temp = Mathf.Min(Input.GetAxis("RightX"), 0) * -1;
        }

        rAngle = temp * MAX_ANGLE;
    }
    void AkiyamaHangetsu()
    {
        Vector2 LeftStick;
        LeftStick.x = Input.GetAxis("RightX");
        LeftStick.y = Input.GetAxis("RightY");

        float length = Mathf.Sqrt(LeftStick.x * LeftStick.x + LeftStick.y * LeftStick.y);//�傫��

        if(length <= 0.7f)//���������ăJ�b�g
        {
            isUnLock = false;
        }
        
        if (length > 0.85f && 
            (Mathf.Atan2(LeftStick.y , LeftStick.x) <= (-Mathf.PI / 2 + 0.2f)) &&
            (Mathf.Atan2(LeftStick.y , LeftStick.x) >= (-Mathf.PI / 2 - 0.2f)))
        {
            isUnLock = true;
        }

        if(isUnLock)
        {
            float temp = ((Input.GetAxis("RightY")) + 1) * 0.5f;
            rAngle = temp * MAX_ANGLE;
            if(LockTex)
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
        //if (Input.GetButton("Rbutton"))
        //if (true)
        {
            if (rAngleSpeed < 0) rAngleSpeed = 0;//�؂�Ԃ�����
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
            if (rAngleSpeed > 0) rAngleSpeed = 0;//�؂�Ԃ�����
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


}
