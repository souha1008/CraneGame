using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHassya : MonoBehaviour
{
    static public FireHassya instance;
    //下は２
    float Y_Zahyou;
    float Y_Vector;
    public GameObject m_Fire;

    bool Down = false;
    bool OldDown = false;

    float OldAngleRadian = 0;

    // Start is called before the first frame update
    void Start()
    {
        OldAngleRadian = 0;
        instance = this;
        Y_Zahyou = transform.position.y;
        Y_Vector = 0;
    }

    private void OnEnable()
    {
        Start();
        if(Fire.instance)        Fire.instance.Y = Y_Zahyou;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        OldDown = Down;

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
        //    Debug.Log("押してる");
        //}
        //else
        //{
        //    Down = false;
        //    Debug.Log("押してない");
        //}

        if (Down)
        {
            Y_Vector = 0;
            Y_Zahyou -= 0.3f;
            if(!OldDown)
            {
                SoundManager.instance.SEPlay("バーナー噴射SE_2");
            }
        }
        else
        {
            Y_Vector += 0.04f;
            Y_Zahyou += Y_Vector;
        }


        Y_Zahyou = Mathf.Max(Y_Zahyou, 2);
        Y_Zahyou = Mathf.Min(Y_Zahyou, transform.position.y);

        float ZeroToOne = (transform.position.y - Y_Zahyou) / (transform.position.y - 2);
        Effect_Buner.Instance.BunerSize = ZeroToOne;


       // Vector3 temp = m_Fire.transform.position;
        Fire.instance.Y = Y_Zahyou;

        //m_Fire.transform.position = temp;
    }
}
