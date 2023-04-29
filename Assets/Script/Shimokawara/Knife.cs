using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public enum KNIFE_STATE
    {
        Have,
        Cut,
        Ground,
        NotCut
    }

    KNIFE_STATE KnifeState;

    float rAngle;
    float MIN_ANGLE = 0;
    float MAX_ANGLE = Mathf.PI * 0.5f;

    int Cnt = 0;

    Vector3 BoundVector;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            BoundVector.x = 0.9f;
        }
        else
        {
            BoundVector.x = -0.9f;
        }
        BoundVector.y = 0.9f;
        BoundVector.z = -0.9f;

        KnifeState = KNIFE_STATE.Have;
    }

    // Update is called once per frame
    void Update()
    {
        if(KnifeState == KNIFE_STATE.Have)
        {
            this.transform.position = knifeHassya.instance.transform.position;
        }
    }
    private void FixedUpdate()
    {

        switch (KnifeState)
        {
            case KNIFE_STATE.Have:

                //RotateKnife();
                if (Input.GetButton("Lbutton"))
                {
                    KnifeState = KNIFE_STATE.Cut;
                    knifeHassya.instance.haveKnife = false;
                }
                break;

            case KNIFE_STATE.Cut:
                UpdateCut();
                break;

            case KNIFE_STATE.Ground:
                //Vector3 tempPos = transform.position;
                //tempPos.z -= (0.05f);
                //transform.position = tempPos;
                Cnt++;
                if(Cnt > 45)
                {
                    Destroy(this.gameObject);
                }

                break;

            case KNIFE_STATE.NotCut:
                Vector3 temp = transform.position;

                transform.position += BoundVector;
                transform.Rotate(140, 0, 0);

                break;

        }

        if(!knifeHassya.instance.gameObject.activeInHierarchy)
        {
            knifeHassya.instance.haveKnife = false;
            knifeHassya.instance.RespawnCnt = 0;
            Destroy(gameObject);
        }

    }

    void UpdateCut()
    {
        bool isGround = false;

        //�L�����N�^�[����^�������ւ̃��C���쐬����
        Ray underRay = new Ray(this.transform.position, new Vector3(0.0f, -1.0f, 0.0f).normalized);
        RaycastHit underHit; //�����������ʂ�������ϐ�
        //���C���΂��ăI�u�W�F�N�g�ɓ������
        if (Physics.Raycast(underRay, out underHit, 10.0f))
        {
            //���������̂��v���b�g�t�H�[���Ȃ�
            if (underHit.collider.gameObject.tag == "EscarateUp" ||
                underHit.collider.gameObject.tag == "EscarateRight" ||
                underHit.collider.gameObject.tag == "EscarateDown"||
                underHit.collider.gameObject.tag == "EscarateNone" )
            {
                float distance = underHit.distance; //���C�̊J�n�ʒu�Ɠ��������I�u�W�F�N�g�̋������擾
                                                    //Debug.Log(distance);
                if (distance < transform.localScale.y / 2 + 0.1f)  //��Unity�����̐g���̏ꍇ0.04���炢�Œn�ʂɐڐG�������
                {
                    isGround = true; //�n�ʂɐڐG���Ă���


                }


            }
        }

        if (!isGround)
        {
            //if (isGo)
            {
                Vector3 temp = transform.position;
                temp.y -= 0.9f;
                transform.position = temp;
            }
        }
        else
        {
            KnifeState = KNIFE_STATE.Ground;
        }
    }

    void UpdateGround()
    {

    }


    public void NotCut()
    {
        KnifeState = KNIFE_STATE.NotCut;
        //Destroy(this.gameObject);
    }


#if false
    void RotateKnife()
    {

        Vector2 LeftStick;
        LeftStick.x = Input.GetAxis("RightX");
        LeftStick.y = Input.GetAxis("RightY");

        float length = Mathf.Sqrt(LeftStick.x * LeftStick.x + LeftStick.y * LeftStick.y);//�傫��

        float temp = ((Input.GetAxis("RightY")) + 1) * 0.5f;
        rAngle = temp * MAX_ANGLE;


        Quaternion rot = Quaternion.AngleAxis(rAngle * 180 / Mathf.PI, Vector3.right);

        transform.rotation = rot;
    }
#endif
}