using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hummer2 : MonoBehaviour
{
    //bool isUnLock = false;
    public GameObject Pusher;

    public enum  PosY
        {
    UP,
    DEFAULT,
    DOWN
    }

    public PosY m_PosY;

    

    static public int CHARGE_TIME = 30;

    PosY[] oldPos = new PosY[CHARGE_TIME];

    // Start is called before the first frame update
    void Start()
    {
        //isUnLock = false;
        m_PosY = PosY.DEFAULT;

        for(int i = 0; i < CHARGE_TIME; i++)
        {
            oldPos[i] = PosY.DEFAULT;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float tempPosY = 0;
        switch (m_PosY)
        {
            case PosY.UP:
                int UpCnt = 0;
                for(int i = 0;i < CHARGE_TIME;i++)
                {
                    if(oldPos[i] == PosY.UP)
                    {
                        UpCnt++;
                    }
                    else
                    {
                        break;
                    }
                    
                }
                tempPosY = ((float)UpCnt / 30) * 3 + 15;
                //tempPosY = 18;
                break;
            case PosY.DEFAULT:
                tempPosY = 15;
                break;
            case PosY.DOWN:
                tempPosY = 5;
                break;

        }

        Debug.Log(tempPosY);

        Pusher.transform.position = new Vector3(transform.position.x, tempPosY,transform.position.z);
    }

    private void FixedUpdate()
    {
        Vector2 LeftStick;
        LeftStick.x = Input.GetAxis("RightX");
        LeftStick.y = Input.GetAxis("RightY");

        for(int i = 0; i < CHARGE_TIME - 1;i++)
        {
            oldPos[CHARGE_TIME - 1 - i] = oldPos[CHARGE_TIME - 2 - i];
        }
        oldPos[0] = m_PosY;

        //ƒ_ƒEƒ“‚Ì—]‰C
        if(oldPos[0] == PosY.DOWN && oldPos[5] != PosY.DOWN)
        {
            m_PosY = PosY.DOWN;
        }
        else
        {
            //‚¤‚¦
            if (LeftStick.y < -0.2f)
            {
                m_PosY = PosY.UP;
            }
            //ã‚¶‚á‚È‚¢
            else
            {
                bool Hummer = true;
                for (int i = 0; i < CHARGE_TIME; i++)
                {
                    if (oldPos[i] != PosY.UP)
                    {
                        Hummer = false;
                        break;
                    }
                }

                if (Hummer)
                {
                    m_PosY = PosY.DOWN;
                }
                else
                {
                    m_PosY = PosY.DEFAULT;
                }
            }
        }

        

        


        Update();
    }
}
