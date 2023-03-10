using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEgg : MonoBehaviour
{
    public bool isGround = false;
    float BallSize;
    Vector3 Vel = Vector3.zero;
    float GLAVITY = 0.006f;
    public GameObject GroundEgg;

    // Start is called before the first frame update
    void Start()
    {
        BallSize = transform.localScale.y/* * transform.lossyScale.x*/;
        GroundEgg.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vel.y -= GLAVITY;


        //�L�����N�^�[����^�������ւ̃��C���쐬����
        Ray underRay = new Ray(this.transform.position, new Vector3(0.0f, -1.0f, 0.0f).normalized);
        //RaycastHit underHit; //�����������ʂ�������ϐ�
        //���C���΂��ăI�u�W�F�N�g�ɓ������
       // if (Physics.Raycast(underRay, out underHit, 10))
        {
            //�z��
            RaycastHit[] hitArray = Physics.RaycastAll(underRay,10);
            //���炢�z�I��
            if(hitArray.Length > 0)
            {
                int justIndex = -1;
                //Debug.Log(hitArray.Length + "�����O�X");
                for (int i = 0; i < hitArray.Length; i++)
                {
                    if (hitArray[i].collider.gameObject.tag != "PlatForm")
                    {
                        continue;
                    }
                    else
                    {
                        if (justIndex < 0)//����
                        {
                            justIndex = i;//platform���
                        }
                        else
                        {
                            if (hitArray[i].distance <= hitArray[justIndex].distance)//�X�V
                            {
                                justIndex = i;
                            }
                        }

                    }
                }
                if(justIndex >= 0)
                {
                    RaycastHit hit = hitArray[justIndex];



                    float distance = hit.distance; //���C�̊J�n�ʒu�Ɠ��������I�u�W�F�N�g�̋������擾
                                                   //Debug.Log(distance);
                    if (distance < BallSize / 2 + 0.1f)  //��Unity�����̐g���̏ꍇ0.04���炢�Œn�ʂɐڐG�������
                    {
                        isGround = true; //�n�ʂɐڐG���Ă���

                        if (Vel.y < 0.0f)
                            Vel.y = 0.0f;

                        Vector3 temp = hit.point;
                        temp.y += BallSize / 2;

                        transform.position = temp;


                        GroundEgg.GetComponent<Renderer>().enabled = true;
                        GroundEgg.transform.position = hit.point;
                        Destroy(this.gameObject);

                    }
                }
               
            }
            
            
        }

        //�G�X�J���[�g����
        if (isGround)
        {
            Vector3 tempPos = transform.position;
            tempPos.z -= 0.05f;
            transform.position = tempPos;
        }

        if (GetComponent<Renderer>().enabled == false)
        {
            Vel = Vector3.zero;
        }

        transform.position += Vel;
    }
}