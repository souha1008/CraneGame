using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class MyButton: CircleFoodsInterFace
{
    CookMoveManager cookMoveManager;
    bool ButtonState;
    bool OnceOK;
    int Cnt = 0;

    void Start()
    {
        cookMoveManager = GameObject.FindObjectOfType<CookMoveManager>();
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

        if(ButtonState && OnceOK && Cnt > 120)
        {
            OnceOK = false;
            //シーン遷移処理
            cookMoveManager.ChangeSign();
            Debug.Log("ボタンシーンチェンジ");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttachFire")
            ButtonState = true;
        if (other.gameObject.tag == "AttachKnife")
            ButtonState = true;
        if (other.gameObject.tag == "AttachHummer")
            ButtonState = true;
        if (other.gameObject.tag == "LeftArm")
            ButtonState = true;
        if (other.gameObject.tag == "RightArm")
            ButtonState = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LeftArm")
            ButtonState = true;
        if (collision.gameObject.tag == "RightArm")
            ButtonState = true;
    }

    public void ButtonReset()
    {
        Start();
    }
}


