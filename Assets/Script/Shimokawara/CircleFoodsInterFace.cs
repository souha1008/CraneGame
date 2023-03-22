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
    RaycastHit LeftHit; //�����������ʂ�������ϐ�
    RaycastHit RightHit; //�����������ʂ�������ϐ�

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
        //�L�����N�^�[����^�������ւ̃��C���쐬����
        Ray LeftRay = new Ray(this.transform.position, new Vector3(-1, 0, 0.0f).normalized);

        //�L�����N�^�[����^�E�����ւ̃��C���쐬����
        Ray RightRay = new Ray(this.transform.position, new Vector3(1, 0, 0.0f).normalized);


        bool bLeftHit = false;
        bool bRightHit = false;


        if (Physics.Raycast(LeftRay, out LeftHit, 10.0f))
        {

            //���������̂�
            if (LeftHit.collider.gameObject == LeftArm)
            {

                leftDistance = LeftHit.distance; //���C�̊J�n�ʒu�Ɠ��������I�u�W�F�N�g�̋������擾
                                                 //Debug.Log(distance);
                                                 //if (leftDistance < BallSize / 2 + 0.1f)  //��Unity�����̐g���̏ꍇ0.04���炢�Œn�ʂɐڐG�������
                {
                    bLeftHit = true;
                    //Debug.Log("�Ђ���");
                }
            }
        }
        if (Physics.Raycast(RightRay, out RightHit, 10.0f))
        {

            //���������̂�
            if (RightHit.collider.gameObject == RightArm)
            {

                rightDistance = RightHit.distance; //���C�̊J�n�ʒu�Ɠ��������I�u�W�F�N�g�̋������擾
                                                   //Debug.Log(distance);
                                                   // (rightDistance < BallSize / 2 + 0.1f)  //��Unity�����̐g���̏ꍇ0.04���炢�Œn�ʂɐڐG�������
                {
                    bRightHit = true;
                    //Debug.Log("�݂�");
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
        //�G�X�J���[�g����
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
        //Debug.Log("�������");

        Vector3 temp = (RightHit.point + LeftHit.point) / 2;
        temp.y = LeftArm.transform.position.y;
        temp.z = LeftArm.transform.position.z;

        this.transform.position = temp;

        if (Vector3.Distance(RightHit.point, LeftHit.point) < 0.5f * BallSize)
        {
            GetComponent<Renderer>().enabled = false;
        }

        //����������
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

        isGround = false; //�n�ʂɐڐG���Ă���


        //�L�����N�^�[����^�������ւ̃��C���쐬����
        Ray underRay = new Ray(this.transform.position, new Vector3(0.0f, -1.0f, 0.0f).normalized);
        RaycastHit underHit; //�����������ʂ�������ϐ�
        //���C���΂��ăI�u�W�F�N�g�ɓ������
        if (Physics.Raycast(underRay, out underHit, 10.0f))
        {
            //���������̂��v���b�g�t�H�[���Ȃ�
            if (underHit.collider.gameObject.tag == "EscarateUp"||
                underHit.collider.gameObject.tag == "EscarateRight"||
                underHit.collider.gameObject.tag == "EscarateDown")
            {
                float distance = underHit.distance; //���C�̊J�n�ʒu�Ɠ��������I�u�W�F�N�g�̋������擾
                                                    //Debug.Log(distance);
                if (distance < BallSize / 2 + 0.1f)  //��Unity�����̐g���̏ꍇ0.04���炢�Œn�ʂɐڐG�������
                {
                    isGround = true; //�n�ʂɐڐG���Ă���

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