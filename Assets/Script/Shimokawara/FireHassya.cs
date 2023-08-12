using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHassya : MonoBehaviour
{
    static public FireHassya instance;
    //���͂Q
    float Y_Zahyou;
    float Y_Vector;
    public GameObject m_Fire;
    //FIRE_STATE OldFireState;

    bool Down = false;
    bool OldDown = false;

    float OldAngleRadian = 0;
    //�ҋ@�t���[��60
    float[] WariaiArray = new float[120];

    public float FireWariai;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < WariaiArray.Length; i++)
        {
            WariaiArray[i] = 0;
        }


        OldAngleRadian = 0;
        instance = this;
        Y_Zahyou = transform.position.y;
        Y_Vector = 0;
    }

    private void OnEnable()
    {
        Start();
        if (Fire.instance)
        {
            Fire.instance.Y = Y_Zahyou;
            Fire.instance.FireState = FIRE_STATE.FIRE_NONE;

            //OldFireState = Fire.instance.FireState;
        }
    }
        // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {


        OldDown = Down;
        //OldFireState = Fire.instance.FireState;

        Down = false;
        Vector2 LeftStick;
        LeftStick.x = Input.GetAxis("RightX");
        LeftStick.y = Input.GetAxis("RightY");

        if (LeftStick.magnitude > 0.4f)
        {
            float Angle = Mathf.Atan2(LeftStick.y, LeftStick.x);
            if (Mathf.Abs(Angle - OldAngleRadian) > 0.1)
            {
                Down = true;
            }
            OldAngleRadian = Angle;
        }

        //if (Input.GetButton("Lbutton"))
        //{
        //    Down = true;
        //    Debug.Log("�����Ă�");
        //}
        //else
        //{
        //    Down = false;
        //    Debug.Log("�����ĂȂ�");
        //}

        if (Down)
        {
            Y_Vector = 0;
            Y_Zahyou -= 0.4f;
            if(!OldDown)
            {
                SoundManager.instance.SEPlay("�o�[�i�[����SE_2");
            }
        }
        else
        {
            Y_Vector += 0.04f;
            Y_Zahyou += Y_Vector;
        }


        Y_Zahyou = Mathf.Max(Y_Zahyou, 2);                      //  2
        Y_Zahyou = Mathf.Min(Y_Zahyou, transform.position.y);   //  21

        float ZeroToOne = (transform.position.y - Y_Zahyou) / (transform.position.y - 2);

        //�z��ҏW
        for (int i = 0; i < WariaiArray.Length - 1; i++)
        {
            WariaiArray[i] = WariaiArray[i + 1];
        }
        WariaiArray[WariaiArray.Length - 1] = ZeroToOne;

        //���`�F�b�N
        bool bFire = true;
        for (int i = 0; i < WariaiArray.Length; i++)
        {
            if (WariaiArray[i] < FireWariai)
            {
               bFire = false;
            }
        }


        //����N
        Effect_Buner.Instance.BunerSize = ZeroToOne;


        //Fire.instance.Y = Y_Zahyou;
        Fire.instance.Y = 2;

        //���f
        if(bFire)
        {
            Fire.instance.FireState = FIRE_STATE.FIRE_FIRE;
        }
        else if(ZeroToOne<0.2f)
        {
            Fire.instance.FireState = FIRE_STATE.FIRE_NONE;
        }
        else
        {
            Fire.instance.FireState = FIRE_STATE.FIRE_AIR;
        }
    
        //if(OldFireState != Fire.instance.FireState)
        //{
        //    Fire.instance.enabled = false;
            
        //}

    }
}
