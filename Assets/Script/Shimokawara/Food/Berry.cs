using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Berry : CircleFoodsInterFace
{
    public int AirCnt = 0;
    bool AirFlag;
    public bool Dry = false;
    BerryPlate[] PlateArray;

    void Start()
    {
        FoodsStart();
    }

    private void OnEnable()
    {
        PlateArray = GameObject.FindObjectsOfType<BerryPlate>();
        GetComponent<General_ColorTransfer>().SetParm(1);
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        if (!isNoAction)
        {
            if (AirFlag)
            {
                AirCnt++;

                if (AirCnt > 40)
                {
                    m_HummerAction = HummerAction.STAY;
                    GetComponent<General_ColorTransfer>().OneToZero(0.1f);
                    Debug.Log("����");
                    Dry = true;
                }
            }
            AirFlag = false;
        }

        if (Dry)
        {
            for (int i = 0; i < PlateArray.Length; i++)
            {
                if (PlateArray[i])
                {
                    float VectorLength = (transform.position - PlateArray[i].transform.position).magnitude;
                    if (VectorLength < 8)
                    {
                        isClear = true;
                    }
                }
            }
        }
        

        FoodsFixedUpdate();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
        {
            if (other.GetComponent<Fire>().FireState == FIRE_STATE.FIRE_AIR)
            {
                AirFlag = true;
            }
            if (other.GetComponent<Fire>().FireState == FIRE_STATE.FIRE_FIRE)
            {
                if (isGround)
                {
                    if (m_FireAction == FireAction.KOGE)
                    {
                        //�����ύX
                        Debug.Log("�ł��֐��Ă΂�邩���H");
                        //GetComponent<Renderer>().material.color = Color.black;
                        if (GetComponent<Material_ColorTransfer>())
                        {
                            Debug.Log("�Ă΂ꂽ");
                            GetComponent<Material_ColorTransfer>().Scorch_Object(3.0f);

                        }
                        SoundManager.instance.SEPlay("�ł���SE");

                        //���肾��
                        GameObject Smoke = (GameObject)Resources.Load("smoke_fx_001");

                        Vector3 tempPos1 = transform.position;
                        // Cube�v���n�u�����ɁA�C���X�^���X�𐶐��A
                        Smoke = Instantiate(Smoke, tempPos1, transform.rotation);
                        Smoke.gameObject.transform.parent = this.transform;

                        //�ύX
                        //�ړ�����]�����Ȃ��悤�ɂ���
                        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                        m_HummerAction = HummerAction.STAY;
                        m_CutAction = CutAction.CANNOT;
                        m_FireAction = FireAction.STAY;
                        m_ChachAction = ChachAction.HARD;

                        isNoAction = true;

                        //Debug.Log("�n���}�[2");
                    }
                }
            }
        }


    }
}
