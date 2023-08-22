using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class MyTutrialButton: CircleFoodsInterFace
{
    CookMoveManager cookMoveManager;
    bool ButtonState;
    bool OnceOK;
    int Cnt = 0;

    public GameObject Button;
    float DefaultY = 4.619977f;

    public CircleFoodsInterFace Food;

    void Start()
    {
        //DefaultY = Button.transform.position.y;

        cookMoveManager = GameObject.FindObjectOfType<CookMoveManager>();
        Button.transform.position = new Vector3(Button.transform.position.x, DefaultY , Button.transform.position.z);
        OnceOK = true;
        ButtonState = false;
        Cnt = 0;
        FoodsStart();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        Cnt++;

        //FoodsFixedUpdate();

        //シーン遷移処理
        if (Food.isNoAction)
        {
            //シーン繰り返し
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(SceneManager.GetActiveScene().name, 1);
            Debug.Log("シーン繰り返し");
        }

        if (ButtonState && OnceOK && Cnt > 120)
        {
            OnceOK = false;
            //シーン遷移処理
            Button.transform.position = new Vector3(Button.transform.position.x, DefaultY - 0.7f, Button.transform.position.z);
            cookMoveManager.ChangeSign();
            Debug.Log("ボタンシーンチェンジ");
            SoundManager.instance.SEPlay("シャッター開閉SE");
            SoundManager.instance.SEPlay("ボタン押下SE");

            //シーン遷移処理
            if (Food)
            {
                if (Food.isClear)
                {
                    //次のシーンへ
                    GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("ResultTest", 1);

                }
                else
                {
                    //シーン繰り返し
                    GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(SceneManager.GetActiveScene().name, 1);
                    Debug.Log("シーン繰り返し");
                }

                if (Food.isNoAction)
                {
                    //シーン繰り返し
                    GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(SceneManager.GetActiveScene().name, 1);
                    Debug.Log("シーン繰り返し");
                }

            }
            else
            {
                //次のシーンへ
                GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("ResultTest", 1);
            }
            

            

        }

    }

    private void OnTriggerStay(Collider other)//元エンター
    {
        if (Cnt > 120)
        {
            if (other.gameObject.tag == "AttachFire")
            {
                if (other.gameObject.GetComponent<Fire>().FireState != FIRE_STATE.FIRE_NONE)
                {
                    ButtonState = true;
                }
            }
        
            if (other.gameObject.tag == "AttachKnife")
            {
                ButtonState = true;
                if(other.GetComponent<Knife>())
                {
                    other.GetComponent<Knife>().NotCut();
                }
            }
               
            if (other.gameObject.tag == "AttachHummer")
                ButtonState = true;
            if (other.gameObject.tag == "LeftArm")
                ButtonState = true;
            if (other.gameObject.tag == "RightArm")
                ButtonState = true;
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Cnt > 120)
        {
            if (collision.gameObject.tag == "LeftArm")
                ButtonState = true;
            if (collision.gameObject.tag == "RightArm")
                ButtonState = true;
        }
    }

    public void ButtonReset()
    {
        Start();
    }
}


