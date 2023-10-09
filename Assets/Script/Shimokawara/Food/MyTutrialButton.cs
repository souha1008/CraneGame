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

    [SerializeField]
    private string nextSceneName;

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

        //�V�[���J�ڏ���
        if (Food.isNoAction)
        {
            //�V�[���J��Ԃ�
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(SceneManager.GetActiveScene().name, 1);
            Debug.Log("�V�[���J��Ԃ�");
        }

        if (ButtonState && OnceOK && Cnt > 120)
        {
            OnceOK = false;
            //�V�[���J�ڏ���
            Button.transform.position = new Vector3(Button.transform.position.x, DefaultY - 0.7f, Button.transform.position.z);
            cookMoveManager.ChangeSign();
            Debug.Log("�{�^���V�[���`�F���W");
            SoundManager.instance.SEPlay("�V���b�^�[�J��SE");
            SoundManager.instance.SEPlay("�{�^������SE");

            //�V�[���J�ڏ���
            if (Food)
            {
                if (Food.isClear)
                {
                    //���̃V�[����
                    GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(nextSceneName, 1);

                }
                else
                {
                    //�V�[���J��Ԃ�
                    GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(SceneManager.GetActiveScene().name, 1);
                    Debug.Log("�V�[���J��Ԃ�");
                }

                if (Food.isNoAction)
                {
                    //�V�[���J��Ԃ�
                    GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(SceneManager.GetActiveScene().name, 1);
                    Debug.Log("�V�[���J��Ԃ�");
                }

            }
            else
            {
                //���̃V�[����
                GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(nextSceneName, 1);
            }
            

            

        }

    }

    private void OnTriggerStay(Collider other)//���G���^�[
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


