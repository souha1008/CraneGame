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

    public GameObject Model1;
    public GameObject Model2;
    public GameObject Effect;

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
                        SoundManager.instance.SEPlay("コーン弾けるSE");
                        isFire = true;
                        float Value = UnityEngine.Random.Range(0.0f,6.24f);
                        float MoveX = Mathf.Cos(Value) * 0.3f;
                        float MoveZ = Mathf.Sin(Value) * 0.3f;
                        Debug.Log(MoveX );
                        Debug.Log( MoveZ);

                        Vel = new Vector3(MoveX, 0.2f, MoveZ);

                        //Destroy(gameObject);
                    }
                }
                FireFlag = false;
            }
        }
        
        if (isFire)
        {
            Model1.SetActive(true);
            Model2.SetActive(false);

            if (Effect)
            {
                Effect.SetActive(true);
                Effect.gameObject.transform.parent = null;
                Effect = null;
            }

        }
        else
        {
            Model1.SetActive(false);
            Model2.SetActive(true);
        }



        //クリア判定
        if(Parent)
        {
            bool TempClearFlag = true;

            for(int i = 0; i < PopCornArray.Length; i++)
            {
                if(!PopCornArray[i])
                {
                    TempClearFlag = false;
                    continue;
                }

                //焼け判定
                if(!PopCornArray[i].isFire)
                {
                    TempClearFlag = false;
                }
                //距離判定
                float VectorLength = (PopCornArray[i].transform.position - Sara.transform.position).magnitude;
                if (VectorLength > 8)
                {
                    TempClearFlag = false;
                    Debug.Log("範囲外");
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
