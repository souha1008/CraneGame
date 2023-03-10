using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Mikan : CircleFoodsInterFace
{

    void Start()
    {
        FoodsStart();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        FoodsFixedUpdate();
    }
    //public enum MIKAN_STATE
    //{
    //    FREE,
    //    GLAB,
    //    //HIT_LEFT,
    //    //HIT_RIGHT
    //}


    //float GLAVITY = 0.006f;
    //Vector3 Vel = Vector3.zero;

    //bool isGround = false;
    //MIKAN_STATE MikanState;

    //public GameObject LeftArm;
    //public GameObject RightArm;

    //float BallSize;
    //RaycastHit LeftHit; //�����������ʂ�������ϐ�
    //RaycastHit RightHit; //�����������ʂ�������ϐ�

    //float leftDistance = 0;
    //float rightDistance = 0;

    //Color DefaultColor;
    //Color GlabColor;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    MikanState = MIKAN_STATE.FREE;
    //    isGround = false;
    //    BallSize = transform.localScale.x/* * transform.lossyScale.x*/;
    //    Debug.Log(transform.localScale.x);

    //    DefaultColor = this.GetComponent<Renderer>().material.color;
    //    GlabColor = this.GetComponent<Renderer>().material.color;
    //    GlabColor.b += 0.6f;

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //Debug.Log(transform.localScale.x);
    //}

    //private void FixedUpdate()
    //{
    //    //�L�����N�^�[����^�������ւ̃��C���쐬����
    //    Ray LeftRay = new Ray(this.transform.position, new Vector3(-1, 0, 0.0f).normalized);

    //    //�L�����N�^�[����^�E�����ւ̃��C���쐬����
    //    Ray RightRay = new Ray(this.transform.position, new Vector3(1, 0, 0.0f).normalized);


    //    bool bLeftHit = false;
    //    bool bRightHit = false;


    //    if (Physics.Raycast(LeftRay, out LeftHit, 10.0f))
    //    {

    //        //���������̂�
    //        if (LeftHit.collider.gameObject == LeftArm)
    //        {

    //            leftDistance = LeftHit.distance; //���C�̊J�n�ʒu�Ɠ��������I�u�W�F�N�g�̋������擾
    //                                             //Debug.Log(distance);
    //                                             //if (leftDistance < BallSize / 2 + 0.1f)  //��Unity�����̐g���̏ꍇ0.04���炢�Œn�ʂɐڐG�������
    //            {
    //                bLeftHit = true;
    //                //Debug.Log("�Ђ���");
    //            }
    //        }
    //    }
    //    if (Physics.Raycast(RightRay, out RightHit, 10.0f))
    //    {

    //        //���������̂�
    //        if (RightHit.collider.gameObject == RightArm)
    //        {

    //            rightDistance = RightHit.distance; //���C�̊J�n�ʒu�Ɠ��������I�u�W�F�N�g�̋������擾
    //                                               //Debug.Log(distance);
    //                                               // (rightDistance < BallSize / 2 + 0.1f)  //��Unity�����̐g���̏ꍇ0.04���炢�Œn�ʂɐڐG�������
    //            {
    //                bRightHit = true;
    //                //Debug.Log("�݂�");
    //            }
    //        }
    //    }

    //    if (bLeftHit && bRightHit && (Vector3.Distance(RightHit.point , LeftHit.point) <= BallSize))
    //    {
    //        MikanState = MIKAN_STATE.GLAB;
    //       // Debug.Log("GLAB");
    //    }
    //    //else if(bLeftHit)
    //    //{
    //    //    MikanState = MIKAN_STATE.HIT_LEFT;
    //    //}
    //    //else if(bRightHit)
    //    //{
    //    //    MikanState = MIKAN_STATE.HIT_RIGHT;
    //    //}
    //    else
    //    {
    //        MikanState = MIKAN_STATE.FREE;
    //    }


    //    switch (MikanState)
    //    {
    //        case MIKAN_STATE.GLAB:
    //            GlabUpdate();
    //            break;

    //        case MIKAN_STATE.FREE:
    //            FreeUpdate();
    //            break;

    //        default:
    //            break;
    //    }


    //}
    // void GlabUpdate()
    //{
    //    this.GetComponent<Renderer>().material.color = GlabColor;
    //    //Debug.Log("�������");

    //    Vector3 temp = (RightHit.point + LeftHit.point) / 2;
    //    temp.y = LeftArm.transform.position.y;
    //    temp.z = LeftArm.transform.position.z;

    //    this.transform.position = temp;

    //    if (Vector3.Distance(RightHit.point, LeftHit.point) < 0.5f * BallSize )
    //    {
    //        Destroy(this.gameObject);
    //    }

    //    //����������
    //    if(Vector3.Distance(RightHit.point, LeftHit.point) < BallSize)
    //    {
    //        Vector3 tempScale = transform.localScale;
    //        tempScale.x = BallSize * (Vector3.Distance(RightHit.point, LeftHit.point) / BallSize);

    //        transform.localScale = tempScale;
    //    }
    //}

    //void FreeUpdate()
    //{
    //    this.GetComponent<Renderer>().material.color = DefaultColor;

    //    transform.position += Vel;

    //    Vel.y -= GLAVITY;



    //    //�L�����N�^�[����^�������ւ̃��C���쐬����
    //    Ray underRay = new Ray(this.transform.position, new Vector3(0.0f, -1.0f, 0.0f).normalized);
    //    RaycastHit underHit; //�����������ʂ�������ϐ�
    //    //���C���΂��ăI�u�W�F�N�g�ɓ������
    //    if (Physics.Raycast(underRay, out underHit, 10.0f))
    //    {
    //        //���������̂��v���b�g�t�H�[���Ȃ�
    //        if (underHit.collider.gameObject.tag == "PlatForm")
    //        {
    //            float distance = underHit.distance; //���C�̊J�n�ʒu�Ɠ��������I�u�W�F�N�g�̋������擾
    //                                                //Debug.Log(distance);
    //            if (distance < BallSize / 2 + 0.1f)  //��Unity�����̐g���̏ꍇ0.04���炢�Œn�ʂɐڐG�������
    //            {
    //                isGround = true; //�n�ʂɐڐG���Ă���

    //                if (Vel.y < 0.0f)
    //                    Vel.y = 0.0f;
    //            }
    //        }
    //    }
    //}
}


