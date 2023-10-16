using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Candle : CircleFoodsInterFace
{
    public int FireCnt = 0;
    bool FireAburareFlag;

    public bool isFire = false;
    bool OldIsFire = false;

    public GameObject Effect;

    private bool once = false;

    private string bgmtitle;

    private CandleGimmick gimmick;

    void Start()
    {
        FoodsStart();
        Effect.SetActive(false);
        
        gimmick = GetComponent<CandleGimmick>();
        bgmtitle = GameObject.FindAnyObjectByType<BGMPlayer>().selectplayTitle;
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        OldIsFire = isFire;

        if (!once)
        {
            if (SoundManager.instance.CheckPlayBGM(bgmtitle) && transform.position.z >= 0)
            {
                once = true;
                isFire = true;
                gimmick.CandleLighting();
            }
        }

        if (!isNoAction)
        {
            if (FireAburareFlag)
            {
                FireCnt++;

                if (FireCnt > 2)
                {
                    m_HummerAction = HummerAction.STAY;
                    isFire = true;
                    gimmick.CandleLighting();
                }
            }
            FireAburareFlag = false;
        }

        FoodsFixedUpdate();

        if(isFire)
        {
            Effect.SetActive(true);
            
            if(!OldIsFire)
            {
                //gimmick.CandleLighting();
                SoundManager.instance.SEPlay("ÇÎÇ§ÇªÇ≠íÖâŒSE");
            }
        }
        
        if(!gimmick.isLight)
        {
            isFire = false;
            Effect.SetActive(false);
        }

        if(OldIsFire == true && isFire == false)
        {
            SoundManager.instance.SEPlay("ÇÎÇ§ÇªÇ≠è¡Ç¶ÇÈSE");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
        {
            if (other.GetComponent<Fire>().FireState == FIRE_STATE.FIRE_FIRE)
                FireAburareFlag = true;
        }
    }
}
