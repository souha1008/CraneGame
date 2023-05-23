using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro�������ۂɕK�v

public class MyText : MonoBehaviour
{
    TextMeshProUGUI text;

    int speedClearTime; // �^�C�����~�b�g�b
    int FPSTime;    // ���t�F�[�Y�̃t���[����
    int AllTime;    // ����܂ł̃t���[����

    float OneFrame; // 1�t���[���̕b�� 

    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "9999";

        speedClearTime = CookMoveManager.instance.SPEED_CLEAR_TIME;
        FPSTime = CookMoveManager.instance.FPS_Time;
        AllTime = CookMoveManager.instance.AllTime;

        OneFrame = 1.0f / 60.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FPSTime = CookMoveManager.instance.FPS_Time;
        AllTime = CookMoveManager.instance.AllTime;
        
        int FrameTime = FPSTime + AllTime;
        float SecTime = (float)FrameTime * OneFrame;
        time = speedClearTime - (int)SecTime;

        text.text = time.ToString("000");
    }
}
