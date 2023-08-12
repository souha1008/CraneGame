using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class PopCorn : CircleFoodsInterFace
{
    public int FireCnt = 0;
    bool FireFlag;

    public bool isFire;

    public bool Parent;
    public PopCorn[] PopCornArray;
    public PopCornSara Sara;

    void Start()
    {
        isFire = false;
        FoodsStart();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        if(!isFire)
        {
            if (!isNoAction)
            {
                if (FireFlag)
                {
                    FireCnt++;

                    if (FireCnt > 10)
                    {
                        isFire = true;
                        Vel = new Vector3(0, 0.2f, 0);

                        //Destroy(gameObject);
                    }
                }
                FireFlag = false;
            }
        }
        


        //ƒNƒŠƒA”»’è
        if(Parent)
        {
            bool TempClearFlag = true;

            for(int i = 0; i < PopCornArray.Length; i++)
            {
                //Ä‚¯”»’è
                if(!PopCornArray[i].isFire)
                {
                    TempClearFlag = false;
                }
                //‹——£”»’è
                float VectorLength = (PopCornArray[i].transform.position - Sara.transform.position).magnitude;
                if (VectorLength > 8)
                {
                    TempClearFlag = false;
                    Debug.Log("”ÍˆÍŠO");
                }
            }

            if(!isClear)
            {
                isClear = TempClearFlag;
            }
        }


        FoodsFixedUpdate();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
        {
            if (other.GetComponent<Fire>().FireState == FIRE_STATE.FIRE_FIRE)
            {
                FireFlag = true;
            }
        }

    }
}
