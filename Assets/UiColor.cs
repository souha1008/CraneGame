using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ALPHA_TYPE
{
    ALPHA_MAX,
    ALPHA_MIN,
    OVER
}

public enum BLACK_TYPE
{
    NATURAL,
    BLACK,
    OVER
}

public class UiColor : MonoBehaviour
{
    public string KeyPures = "Rbutton";

    ALPHA_TYPE GoAlpha = ALPHA_TYPE.ALPHA_MAX;
    float[] GoalAlpha = new float[(int)(ALPHA_TYPE.OVER)] {1.0f,0.3f };
    float NowAlpha = 1.0f;

    BLACK_TYPE GoBlack = BLACK_TYPE.NATURAL;
    float[] GoalR;
    float NowR = 1.0f;

    float[] GoalG;
    float NowG = 1.0f;

    float[] GoalB;
    float NowB = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        NowR = this.GetComponent<Image>().color.r;
        GoalR = new float[(int)(BLACK_TYPE.OVER)] { NowR, 0.2f };

        NowG = this.GetComponent<Image>().color.g;
        GoalG = new float[(int)(BLACK_TYPE.OVER)] { NowG, 0.2f };

        NowB = this.GetComponent<Image>().color.b;
        GoalB = new float[(int)(BLACK_TYPE.OVER)] { NowB, 0.2f };




        //Alpha = GoalAlpha[(int)(ALPHA_TYPE.ALPHA_MAX)];
    }

    // Update is called once per frame
    void Update()
    {
       UpdateAlpha();
       UpdateBlack();
    }

    void UpdateAlpha()
    {
        GameObject PlayerSan = GameObject.Find("Player");
        Rigidbody PlayerBody = PlayerSan.GetComponent<Rigidbody>();

        float PlayerYokoMove = PlayerBody.velocity.x;
        float PlayerTateMove = PlayerBody.velocity.y;

        //if (Mathf.Abs(PlayerYokoMove) < 1.0f && Mathf.Abs(PlayerTateMove) < 1.0f && Player.instance.touchFg == true)
        {
            GoAlpha = ALPHA_TYPE.ALPHA_MAX;

        }
        //else
        {
            GoAlpha = ALPHA_TYPE.ALPHA_MIN;


        }


        if (GoAlpha == ALPHA_TYPE.ALPHA_MIN)
        {
            NowAlpha = Mathf.Max(NowAlpha - 0.01f, GoalAlpha[(int)(ALPHA_TYPE.ALPHA_MIN)]);
        }
        else//if 大きいほうへ
        {
            NowAlpha = Mathf.Min(NowAlpha + 0.01f, GoalAlpha[(int)(ALPHA_TYPE.ALPHA_MAX)]);
        }


        Color NowColor = this.GetComponent<Image>().color;
        this.GetComponent<Image>().color = new Color(NowColor.r, NowColor.g, NowColor.b, NowAlpha);

       
    }

    void UpdateBlack()
    {
        if(KeyPures != "null")
        {
            if (Input.GetButton(KeyPures))
            {
                GoBlack = BLACK_TYPE.BLACK;

            }
            else
            {
                GoBlack = BLACK_TYPE.NATURAL;
            }
        }
        


        if (GoBlack == BLACK_TYPE.BLACK)
        {
            NowR = Mathf.Max(NowR - 0.1f, GoalR[(int)(BLACK_TYPE.BLACK)]);
            NowG = Mathf.Max(NowG - 0.1f, GoalG[(int)(BLACK_TYPE.BLACK)]);
            NowB = Mathf.Max(NowB - 0.1f, GoalB[(int)(BLACK_TYPE.BLACK)]);
        }
        else//if 元の色へ
        {
            NowR = Mathf.Min(NowR + 0.1f, GoalR[(int)(BLACK_TYPE.NATURAL)]);
            NowG = Mathf.Min(NowG + 0.1f, GoalG[(int)(BLACK_TYPE.NATURAL)]);
            NowB = Mathf.Min(NowB + 0.1f, GoalB[(int)(BLACK_TYPE.NATURAL)]);

            //Debug.Log("元の色へ");
            //Debug.Log(GoalR[(int)(BLACK_TYPE.NATURAL)]);
            //Debug.Log(GoalG[(int)(BLACK_TYPE.NATURAL)]);
            //Debug.Log(GoalB[(int)(BLACK_TYPE.NATURAL)]);
        }


        Color NowColor = this.GetComponent<Image>().color;
        this.GetComponent<Image>().color = new Color(NowR, NowG, NowB, NowColor.a);
    }

    public void RedBlueChange()
    {
        float TempR = NowR;
        float TempB = NowB;

        NowR = TempB;
        NowB = TempR;

        float TempNatuR = GoalR[(int)(BLACK_TYPE.NATURAL)];
        float TempNatuB = GoalB[(int)(BLACK_TYPE.NATURAL)];

        GoalR[(int)(BLACK_TYPE.NATURAL)] = TempNatuB;
        GoalB[(int)(BLACK_TYPE.NATURAL)] = TempNatuR;
    }
}
